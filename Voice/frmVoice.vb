Imports System.Speech
Imports System.Speech.Recognition

Public Class frmVoice
    Dim WithEvents reg As New Recognition.SpeechRecognitionEngine
    Private Sub setcolor(ByVal color As System.Drawing.Color)
        Dim synth As New Synthesis.SpeechSynthesizer
        Me.BackColor = color

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reg.SetInputToDefaultAudioDevice()
        Dim gram As New Recognition.SrgsGrammar.SrgsDocument
        Dim colorr As New Recognition.SrgsGrammar.SrgsRule("coloe")
        Dim colorlist As New Recognition.SrgsGrammar.SrgsOneOf("red", "yellow", "indigo", "aqua", "green", "blue")

        colorr.Add(colorlist)
        gram.Rules.Add(colorr)
        gram.Root = colorr
        reg.LoadGrammar(New Recognition.Grammar(gram))
        reg.RecognizeAsync()



    End Sub

    Private Sub reg_RecognizeCompleted(sender As Object, e As RecognizeCompletedEventArgs) Handles reg.RecognizeCompleted
        reg.RecognizeAsync()

    End Sub

    Private Sub reg_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs) Handles reg.SpeechRecognized
        Select Case e.Result.Text
            Case "red"
                setcolor(Color.Red)

            Case "yellow"
                setcolor(Color.Yellow)

            Case "indigo"
                setcolor(Color.Indigo)

            Case "aqua"
                setcolor(Color.Aqua)

            Case "green"
                setcolor(Color.Green)

            Case "blue"
                setcolor(Color.Blue)
        End Select
    End Sub
End Class
