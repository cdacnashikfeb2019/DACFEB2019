Module App

	Sub Main()
		Dim name As String = InputBox("Your Name")
		Dim age As Integer = InputBox("Your Age")
		Dim greeter As New Greeting.Greeter
		MsgBox(greeter.Greet(name, age > 20))
	End Sub

End 
