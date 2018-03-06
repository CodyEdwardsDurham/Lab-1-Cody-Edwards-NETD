''' Title:  Average Units Shiped
''' Author: Cody Edwards 100666080
''' Since:  Feburary 1st
''' Description: Program to Calulcate the average units shipped at the end of every week
''' CRN: NETD-2202-04


Public Class frmAverageUnitsShipped
    Dim counter As Integer = 0 ' counter varaiable 
    Dim listArray(7) As Integer ' array to store each days sales 
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        Dim isNum As Integer 'temp variable for the tryparse method 
        Dim average As Single 'average variable to show and hold the average number of sales 
        If Int32.TryParse(tbUnits.Text, isNum) Then 'Makes sure that user input is a Whole Number
            If CInt(tbUnits.Text) < 1000 And CInt(tbUnits.Text) > 0 Then 'checks if the user input is between 0 and 1000
                listArray(counter) = CInt(tbUnits.Text) 'stores that input in the array 
                tbList.Text += (listArray(counter).ToString) + Environment.NewLine 'outputs the array to the text box 
                counter = counter + 1 'increment the counter 
                lbDay.Text = "Day: " + counter.ToString 'move to the next day
                tbUnits.Clear() 'clears the input text box 
            Else
                MessageBox.Show("Between 0 and 1000 inclusive") 'if it wasnt between 0 and 1000 show error
                tbUnits.Clear()
            End If
        Else
            MessageBox.Show("Numeric Entrys Only") ' if it wasnt numeric show error 
            tbUnits.Clear()
        End If
        If counter >= 7 Then 'checks what day it is and if its day 7 it will start calculating thee average 
            For i As Integer = 0 To 6 'for loop to calculate the average 
                average += listArray(i)
            Next
            average = average / 7
            lbAnswer.Text = "Average Per Day: " + Math.Round(average, 2).ToString 'showing the answer in the answer label and also rounding it to 2 decimals 
            counter = 0
            tbList.Enabled = False
            tbUnits.Enabled = False 'disableing all the buttons and reseting the rounder 
            btnEnter.Enabled = False
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit() 'exits the program when the exit button is clicked 
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        tbList.Clear()
        counter = 0
        tbList.Clear()
        tbUnits.Clear()
        lbDay.Text = "Day: "
        tbUnits.Clear()
        tbList.Enabled = True 'resets all variables and text boxes if the reset button is clicked 
        tbUnits.Enabled = True
        btnEnter.Enabled = True
        lbAnswer.Text = ""
        tbUnits.Focus()
    End Sub
End Class
