Imports Microsoft.VisualBasic
Imports System.Security.Cryptography

Public Class cHash


    ''' <summary>
    ''' Computes the hash.
    ''' </summary>
    ''' <param name="plainText">The plain text.</param>
    ''' <returns></returns>
    Public Shared Function ComputeHash(ByVal plainText As String) As String
        Try
            Dim minSaltSize As Integer = 4
            Dim maxSaltSize As Integer = 8

            Dim random As New Random()

            Dim saltSize As Integer = random.Next(minSaltSize, maxSaltSize)

            Dim saltBytes = New Byte(saltSize - 1) {}

            Dim rng As RNGCryptoServiceProvider
            rng = New RNGCryptoServiceProvider()

            rng.GetNonZeroBytes(saltBytes)

            Dim plainTextBytes As Byte()
            plainTextBytes = Encoding.UTF8.GetBytes(plainText)

            Dim plainTextWithSaltBytes() As Byte = _
                New Byte(plainTextBytes.Length + saltBytes.Length - 1) {}

            Dim I As Integer
            For I = 0 To plainTextBytes.Length - 1
                plainTextWithSaltBytes(I) = plainTextBytes(I)
            Next I

            For I = 0 To saltBytes.Length - 1
                plainTextWithSaltBytes(plainTextBytes.Length + I) = saltBytes(I)
            Next I

            Dim hash As HashAlgorithm = New SHA1Managed 'SHA256Managed

            Dim hashBytes As Byte()
            hashBytes = hash.ComputeHash(plainTextWithSaltBytes)

            Dim hashWithSaltBytes() As Byte = _
                                       New Byte(hashBytes.Length + _
                                                saltBytes.Length - 1) {}

            For I = 0 To hashBytes.Length - 1
                hashWithSaltBytes(I) = hashBytes(I)
            Next I

            For I = 0 To saltBytes.Length - 1
                hashWithSaltBytes(hashBytes.Length + I) = saltBytes(I)
            Next I

            Dim hashValue As String
            hashValue = Convert.ToBase64String(hashWithSaltBytes)

            ComputeHash = hashValue
        Catch ex As Exception
            cLogging.AddLog(String.Format("cHash.ComputeHash: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Computes the hash.
    ''' </summary>
    ''' <param name="plainText">The plain text.</param>
    ''' <param name="saltBytes">The salt bytes.</param>
    ''' <returns></returns>
    Public Shared Function ComputeHash(ByVal plainText As String, _
                                      ByVal saltBytes() As Byte) _
                          As String

        Try
            If (saltBytes Is Nothing) Then

                Dim minSaltSize As Integer = 4
                Dim maxSaltSize As Integer = 8

                Dim random As New Random()

                Dim saltSize As Integer = random.Next(minSaltSize, maxSaltSize)

                saltBytes = New Byte(saltSize - 1) {}

                Dim rng As RNGCryptoServiceProvider
                rng = New RNGCryptoServiceProvider()

                rng.GetNonZeroBytes(saltBytes)
            End If

            Dim plainTextBytes As Byte()
            plainTextBytes = Encoding.UTF8.GetBytes(plainText)

            Dim plainTextWithSaltBytes() As Byte = _
                New Byte(plainTextBytes.Length + saltBytes.Length - 1) {}

            Dim I As Integer
            For I = 0 To plainTextBytes.Length - 1
                plainTextWithSaltBytes(I) = plainTextBytes(I)
            Next I

            For I = 0 To saltBytes.Length - 1
                plainTextWithSaltBytes(plainTextBytes.Length + I) = saltBytes(I)
            Next I

            Dim hash As HashAlgorithm = New SHA1Managed 'SHA256Managed

            Dim hashBytes As Byte()
            hashBytes = hash.ComputeHash(plainTextWithSaltBytes)

            Dim hashWithSaltBytes() As Byte = _
                                       New Byte(hashBytes.Length + _
                                                saltBytes.Length - 1) {}

            For I = 0 To hashBytes.Length - 1
                hashWithSaltBytes(I) = hashBytes(I)
            Next I

            For I = 0 To saltBytes.Length - 1
                hashWithSaltBytes(hashBytes.Length + I) = saltBytes(I)
            Next I

            Dim hashValue As String
            hashValue = Convert.ToBase64String(hashWithSaltBytes)

            ComputeHash = hashValue
        Catch ex As Exception
            cLogging.AddLog(String.Format("cHash.ComputeHash: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Compares a hash of the specified plain text value to a given hash
    ''' value. Plain text is hashed with the same salt value as the original
    ''' hash.
    ''' </summary>
    ''' <param name="plainText">Plain text to be verified against the specified hash. The function
    ''' does not check whether this parameter is null.</param>
    ''' </param>
    ''' <param name="hashValue">Base64-encoded hash value produced by ComputeHash function. This valueincludes the original salt appended to it.
    ''' </param>
    ''' <returns>If computed hash mathes the specified hash the function the return
    ''' value is true; otherwise, the function returns false.</returns>
    Public Shared Function VerifyHash(ByVal plainText As String, ByVal hashValue As String) _
                           As Boolean
        Try

            If hashValue = Nothing Then
                Return False
            End If

            Dim hashWithSaltBytes As Byte() = Convert.FromBase64String(hashValue)

            Dim hashSizeInBits As Integer = 160
            Dim hashSizeInBytes As Integer

            hashSizeInBytes = hashSizeInBits / 8

            If (hashWithSaltBytes.Length < hashSizeInBytes) Then
                VerifyHash = False
            End If

            Dim saltBytes() As Byte = New Byte(hashWithSaltBytes.Length - _
                                               hashSizeInBytes - 1) {}

            Dim I As Integer
            For I = 0 To saltBytes.Length - 1
                saltBytes(I) = hashWithSaltBytes(hashSizeInBytes + I)
            Next I

            Dim expectedHashString As String
            expectedHashString = ComputeHash(plainText, saltBytes)

            'Dim expectedHashString2 As String
            'expectedHashString2 = ComputeHash(plainText)

            VerifyHash = (hashValue = expectedHashString)
        Catch ex As Exception
            cLogging.AddLog(String.Format("cHash.VerifyHash: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
        
    End Function

    ''' <summary>
    ''' Gets the random generated code 16 characters.
    ''' </summary>
    ''' <param name="text">The text.</param>
    ''' <returns></returns>
    Public Shared Function getRandomGeneratedCode(ByVal text As String) As String
        Return ComputeHash(text).Substring(0, 16)
    End Function

    ''' <summary>
    ''' Gets the random generated code.
    ''' </summary>
    ''' <param name="text">The text.</param>
    ''' <param name="hashlength">The hashlength.</param>
    ''' <returns></returns>
    Public Shared Function getRandomGeneratedCode(ByVal text As String, ByVal hashlength As Integer) As String
        Return ComputeHash(text).Substring(0, hashlength)
    End Function
End Class
