Sub StockCompilerA():

Dim ws As Worksheet
Dim lrRaw As Long

For Each ws In ActiveWorkbook.Worksheets
    
    'Set I and J headers
    ws.Range("I1").Value = "Ticker"
    ws.Range("J1").Value = "Total Stock Volume"
    
    'Find the last non-blank cell in column A(1)
    lrRaw = ws.Cells(Rows.Count, 1).End(xlUp).Row
    
    
    'initialize first ticker value
    ws.Range("I2").Value = ws.Range("A2").Value
    
    'for each in column A
    For r = 2 To lrRaw

        'find last ticker value
        Dim t As Integer
        t = ws.Cells(Rows.Count, 9).End(xlUp).Row
        
       'if checked ticker is same as last tallyed ticker, then add value. Otherwise, ticker symbol to next line
       
        If ws.Cells(t, 9).Value = ws.Cells(r, 1).Value Then
            
            ws.Cells(t, 10).Value = ws.Cells(t, 10).Value + ws.Cells(r, 7).Value
            
            Else
            
            ws.Cells(t + 1, 9).Value = ws.Cells(r, 1).Value
            ws.Cells(t, 10).Value = ws.Cells(t, 10).Value + ws.Cells(r, 7).Value

    
        End If
    



    
    Next r

Next ws

End Sub

