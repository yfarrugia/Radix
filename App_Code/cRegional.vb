Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Google.API.Language

''' <summary>
''' Handles all regional related information
''' </summary>
Public Class cRegional
    ''' <summary>
    ''' Translates the specified tolanguage.
    ''' </summary>
    ''' <param name="tolanguage">The tolanguage.</param>
    ''' <param name="text">The text.</param>
    ''' <returns></returns>
    Public Shared Function Translate(ByVal tolanguage As String, ByVal text As String) As String
        Try
            Dim gclient As New Google.API.Translate.TranslateClient
            Dim tolang As Google.API.Language = CType(System.Enum.Parse(GetType(Google.API.Language), tolanguage), Google.API.Language)

            Return gclient.Translate(text, Google.API.Language.Unknown, tolang, Google.API.Translate.TranslateFormat.text)
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.Translate: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Detects the language of a given text.
    ''' </summary>
    ''' <param name="Text">The text.</param>
    ''' <returns></returns>
    Public Shared Function DetectLanguage(ByVal Text As String) As String
        Try
            Dim gclient As New Google.API.Translate.TranslateClient
            Dim isRelaiable As Boolean
            Dim confidence As Double
            Dim lang As Google.API.Language = gclient.Detect(Text, isRelaiable, confidence)
            Return CType(lang, Google.API.Language).ToString
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.DetectLanguage: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the language code from language.
    ''' </summary>
    ''' <param name="Language">The language.</param>
    ''' <returns></returns>
    Public Shared Function GetLanguageCodeFromLanguage(ByVal Language As String) As String
        Try
            Return Convert.ToString(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT LanguageCode FROM tblLanguage WHERE Language = '{0}'", Language))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetLanguageCodeFromLanguage: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the lang code from ID.
    ''' </summary>
    ''' <param name="LangID">The lang ID.</param>
    ''' <returns></returns>
    Public Shared Function GetLangCodeFromID(ByVal LangID As Integer) As String
        Try
            Return Convert.ToString(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT LanguageCode FROM tblLanguage WHERE LanguageID = '{0}'", LangID))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetLangCodeFromID: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the language from lang ID.
    ''' </summary>
    ''' <param name="LangID">The lang ID.</param>
    ''' <returns></returns>
    Public Shared Function GetLanguageFromLangID(ByVal LangID As Integer) As String
        Try
            Return Convert.ToString(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT Language FROM tblLanguage WHERE LanguageID = '{0}'", LangID))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetLanguageFromLangID: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the language ID from language code.
    ''' </summary>
    ''' <param name="LangCode">The lang code.</param>
    ''' <returns></returns>
    Public Shared Function GetLanguageIDfromLanguageCode(ByVal LangCode As String) As Integer
        Try
            Return Convert.ToInt64(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT LanguageID FROM tblLanguage WHERE LanguageCode = '{0}'", LangCode))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetLanguageIDfromLanguageCode: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the language ID from language.
    ''' </summary>
    ''' <param name="Lang">The lang.</param>
    ''' <returns></returns>
    Public Shared Function getLanguageIDfromLanguage(ByVal Lang As String) As Integer
        Try
            Return Convert.ToInt64(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT LanguageID FROM tblLanguage WHERE Language = '{0}'", Lang))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.getLanguageIDfromLanguage: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Gets all languages.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function getAllLanguages() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT LanguageID, Language FROM tblLanguage ORDER BY Language ASC"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.getAllLanguages: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the langauge from language code.
    ''' </summary>
    ''' <param name="LangCode">The lang code.</param>
    ''' <returns></returns>
    Public Shared Function getLangaugefromLanguageCode(ByVal LangCode As String) As String
        Try
            Return Convert.ToString(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT Language FROM tblLanguage WHERE (LanguageCode = '{0}')", LangCode))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.getLangaugefromLanguageCode: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the countries.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetCountries() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT Country, CountryID FROM tblCountry WHERE Accepted = 'True' ORDER BY Country ASC"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetCountries: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the nationalities.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetNationalities() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT Nationality, NationalityID FROM tblNationality ORDER BY Nationality ASC"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetNationalities: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Gets the post code regex.
    ''' </summary>
    ''' <param name="selectedCountry">The selected country.</param>
    ''' <returns></returns>
    Public Shared Function GetPostCodeRegex(ByVal selectedCountry As String) As String
        Try
            Select Case selectedCountry
                Case "Germany"
                    Return "(D-)?\d{5}"
                Case "China"
                    Return "\d{6}"
                Case "Japan"
                    Return "\d{3}(-(\d{4}|\d{2}))?"
                Case "France"
                    Return "\d{5}"
                Case "United States"
                    Return "\d{5}(-\d{4})?"
                Case Else
                    Return "[0-9a-zA-Z\-]+"
            End Select
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetPostCodeRegex: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Gets the phone number regex.
    ''' </summary>
    ''' <param name="selectedCountry">The selected country.</param>
    ''' <returns></returns>
    Public Shared Function GetPhoneNumberRegex(ByVal selectedCountry As String) As String
        Try
            Select Case selectedCountry
                Case "Germany"
                    Return "((\(0\d\d\) |(\(0\d{3}\) )?\d )?\d\d \d\d \d\d|\(0\d{4}\) \d \d\d-\d\d?)"
                Case "China"
                    Return "(\(\d{3}\)|\d{3}-)?\d{8}"
                Case "Japan"
                    Return "(0\d{1,4}-|\(0\d{1,4}\) ?)?\d{1,4}-\d{4}"
                Case "France"
                    Return "(0( \d|\d ))?\d\d \d\d(\d \d| \d\d )\d\d"
                Case "United States"
                    Return "((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"
                Case Else
                    Return "[0-9\-]+"
            End Select
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetPhoneNumberRegex: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the country ID.
    ''' </summary>
    ''' <param name="countryName">Name of the country.</param>
    ''' <returns></returns>
    Public Shared Function GetCountryID(ByVal countryName As String) As Integer
        Try
            Return Convert.ToInt32(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT CountryID FROM tblCountry WHERE Country = '{0}'", countryName))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetCountryID: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the country.
    ''' </summary>
    ''' <param name="countryID">The country ID.</param>
    ''' <returns></returns>
    Public Shared Function GetCountry(ByVal countryID As Integer) As String
        Try
            Return Convert.ToString(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT Country FROM tblCountry WHERE CountryID = '{0}'", countryID))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetCountry: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the approved countries.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetApprovedCountries() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT tblCountry.CountryID, tblCountry.Country, tblCountry.CountryCode AS [Country Code], tblLanguage.Language, tblLanguage.LanguageCode AS [Language Code] " & _
                            "FROM tblCountry INNER JOIN " & _
                            "tblLanguage ON tblCountry.LanguageID = tblLanguage.LanguageID " & _
                            "WHERE (tblCountry.Accepted = 'True')"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetApprovedCountries: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the approved countries.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetUnApprovedCountries() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT tblCountry.CountryID, tblCountry.Country " & _
                            "FROM tblCountry " & _
                            "WHERE (tblCountry.Accepted = 'False')"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.GetApprovedCountries: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Updated a selected country to an Accepted status.
    ''' </summary>
    ''' <param name="CountryToApprove">The selected country ID to be updated.</param>
    ''' <returns></returns>
    Public Shared Function SetApprovedCountry(ByVal CountryToApprove As Integer) As Integer
        Try
            Return cDBManager.ExecuteNonQuery(New SqlCommand("UPDATE tblCountry SET Approved = 'True' WHERE CountryID = '" + CountryToApprove + "'"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cRegional.SetApprovedCountry: ", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

End Class
