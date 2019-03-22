Sub StockCompilerC():

On Error GoTo Whoa

Dim ws As Worksheet
Dim lrRaw As Long

For Each ws In ActiveWorkbook.Worksheets
  
    'Set all headers
    ws.Range("I1").Value = "Ticker"
    ws.Range("J1").Value = "Yearly Change"
    ws.Range("K1").Value = "Percent Change"
    ws.Range("L1").Value = "Total Stock Volume"
    ws.Range("P1").Value = "Ticker"
    ws.Range("Q1").Value = "Value"
    ws.Range("O2").Value = "Greatest % Increase"
        ws.Range("Q2").NumberFormat = "0.00%"
    ws.Range("O3").Value = "Greatest % Decrease"
        ws.Range("Q3").NumberFormat = "0.00%"
    ws.Range("O4").Value = "Greatest Total Volume"
    
    'Find the last non-blank cell in column A(1)
    lrRaw = ws.Cells(Rows.Count, 1).End(xlUp).Row
    
    
    
    'initialize first ticker name
    ws.Range("I2").Value = ws.Range("A2").Value
    'initialze first ticker open value
    ws.Range("J2").Value = ws.Range("C2").Value
    
  
'**column name cheatsheet**
'1: ticker
'2: Date
'3: open
'4: high
'5: low
'6: Close
'7: vol
'8: null
'9: ticker
'10: yearly Change
'11: Percent Change
'12: total stock volume
        
        
        
'***COMPILER***


    'for each column A
    For r = 2 To lrRaw
       
        Dim t As Integer
        t = ws.Cells(Rows.Count, 9).End(xlUp).Row
       
       'if raw ticker matches total ticker
        If ws.Cells(t, 9).Value = ws.Cells(r, 1).Value Then
            'add daily volume to total volume
            ws.Cells(t, 12).Value = ws.Cells(t, 12).Value + ws.Cells(r, 7).Value
            'if working iteration is last on sheet
            If r = lrRaw Then
                'use close value from this row to calculate delta
                
                'percent change
                ws.Cells(t, 11).Value = (ws.Cells(r, 6).Value - ws.Cells(t, 10).Value) / ws.Cells(t, 10).Value
                'annual change + conditional formatting
                ws.Cells(t, 10).Value = ws.Cells(r, 6).Value - ws.Cells(t, 10).Value
                ws.Cells(t, 10).NumberFormat = "0.00"
                ws.Cells(t, 11).NumberFormat = "0.00%"
                If ws.Cells(t, 10).Value > 0 Then
                    ws.Cells(t, 10).Interior.ColorIndex = 4
                    Else
                    ws.Cells(t, 10).Interior.ColorIndex = 3
                End If

                If ws.Cells(t, 11).Value > ws.Range("Q2").Value Then
                    ws.Range("P2").Value = ws.Cells(t, 9).Value
                    ws.Range("Q2").Value = ws.Cells(t, 11).Value

                ElseIf ws.Cells(t, 11).Value < ws.Range("Q3").Value Then
                    ws.Range("P3").Value = ws.Cells(t, 9).Value
                    ws.Range("Q3").Value = ws.Cells(t, 11).Value
                End If

                If ws.Cells(t, 12).Value > ws.Range("Q4").Value Then
                    ws.Range("P3").Value = ws.Cells(t, 9).Value
                    ws.Range("Q4").Value = ws.Cells(t, 12).Value
                End If

            End If
            
        Else
            'calculate yearly change of previous ticker value using previously stored open value
            'percent change
            ws.Cells(t, 11).Value = (ws.Cells(r - 1, 6).Value - ws.Cells(t, 10).Value) / ws.Cells(t, 10).Value
            'annual change
            ws.Cells(t, 10).Value = ws.Cells(r - 1, 6).Value - ws.Cells(t, 10).Value
            ws.Cells(t, 10).NumberFormat = "0.00"
            ws.Cells(t, 11).NumberFormat = "0.00%"
            If ws.Cells(t, 10).Value > 0 Then
                    ws.Cells(t, 10).Interior.ColorIndex = 4
                    Else
                    ws.Cells(t, 10).Interior.ColorIndex = 3
                End If
            If ws.Cells(t, 11).Value > ws.Range("Q2").Value Then
                    ws.Range("P2").Value = ws.Cells(t, 9).Value
                    ws.Range("Q2").Value = ws.Cells(t, 11).Value

                ElseIf ws.Cells(t, 11).Value < ws.Range("Q3").Value Then
                    ws.Range("P3").Value = ws.Cells(t, 9).Value
                    ws.Range("Q3").Value = ws.Cells(t, 11).Value
                End If

                If ws.Cells(t, 12).Value > ws.Range("Q4").Value Then
                    ws.Range("P4").Value = ws.Cells(t, 9).Value
                    ws.Range("Q4").Value = ws.Cells(t, 12).Value
                End If
                
            '+1 to total row count
             t = t + 1
            
            'add new stock ticker ID to list
            ws.Cells(t, 9).Value = ws.Cells(r, 1).Value
            'add volume value to new row
            ws.Cells(t, 12).Value = ws.Cells(t, 12).Value + ws.Cells(r, 7).Value
            'store next opening value to new row
            ws.Cells(t, 10).Value = ws.Cells(r, 3)
                  
            
        End If
            
    Next r

Next ws


LetsContinue:
    Exit Sub

Whoa:
    '~~> This gives the exact desription and the error number of the error
    MsgBox "Description     : " & Err.Description & vbNewLine & _
           "Error Number    : " & Err.Number

    '~~> This part resumes the code without breaking it :)
    Resume LetsContinue








End Sub




