Imports System.Data.SqlClient
Imports System.IO

Module modVariables
    Public dbPath As String = "Data Source=DESKTOP-2LLV29I\MSSQLSERVER01;Initial Catalog=EzeeDB;Integrated Security=True"
    Public dataAdapter As SqlDataAdapter
    Public con As SqlConnection
    Public cmd As SqlCommand
    Public iterat As Integer
    Public i As Integer
    Public sql As String = ""
    Public reader As SqlDataReader
    Public getCode As String = ""
    Public getAcct As String = ""
    Public err As New ErrorProvider
    Public setDOB As Date
    Public CalcDOB As Integer
    Public selectAcctNum As clsSelect
    Public gender As String = ""
    Public clientDateJoin As New DateTime
    Public empDateJoin As New DateTime
    Public clientFullname As String = ""
    Public IDName As String = ""
    Public data As Byte()
    Public iterate As Boolean
    Public logUser As ComboBox
    Public logUcode As String
    Public stillOwes As Boolean
    Public Loops As Integer
    Public Interests As Double
    Public Principal As Double
    Public Rates As Double
    Public Total As Double
    Public Times As Double
    Public taxRate As Double
    Public MonthlyRepay As Double
    Public GetAmount As Double
    Public LoanReceiptCode As String
    Public ReceiptCode As String
    Public HolderName As String
    Public kUser As String

    Public EMPLOCODE As String
    Public actName As String
    Public actNum As String
    Public actBalance As Double
    Public LoadDate As New DateTimePicker
End Module
