Sub Main
	EraseTrajectories
	SetTimeStep 0.5
	satuX = GetMarkX("Tanda1")
	satuY = GetMarkY("Tanda1")
	targetX = GetMarkX("Target")
	targetY = GetMarkY("Target")
	homeX = GetMarkX("Home")
	homeY = GetMarkY("Home")
	SetWheelSpeed(0,5,5)
	Dim maju, telusur, balik, berhenti, tmpX1, tmpY1, tmpX2, tmpY2
	maju = 1
	telusur = 0
	balik = 0
	berhenti = 0
	Do
		mobotX = GetMobotX(0)
		mobotY = GetMobotY(0)
		sensor5 = MeasureRange(0,5,0)
		sensor3 = MeasureRange(0,3,0)
		sensor6 = MeasureRange(0,6,0)
		sensor4 = MeasureRange(0,4,0)
		If maju = 1 Then
			If sensor5 < 0.7 Or sensor3 < 1 Then
				telusur = 1
				maju = 0
			Else
				SetWheelSpeed(0,5,5)
			End If
		ElseIf telusur = 1 Then
			tmpX1 = mobotX - satuX
			tmpY1 = mobotY - satuY
			tmpX2 = mobotX - targetX
			tmpY2 = mobotY - targetY
			If (tmpX1 < 0.2 And tmpX1 > -0.2) And (tmpY1 < 0.2 And tmpY1 > -0.2) Then
				telusur = 0
				maju = 1
			ElseIf (tmpX2 < 0.2 And tmpX2 > -0.2) And (tmpY2 < 0.2 And tmpY2 > -0.2) Then
				telusur = 0
				balik = 1
			ElseIf sensor5 < 0.7 Or sensor6 < 0.5 Then
				If sensor4 < 0.2 Then
					SetWheelSpeed(0,-2,-5)
				Else
           			SetWheelSpeed(0,4,0)
           		End If
        	ElseIf sensor5 > 1 Then
        		If sensor6 > 0.5 Then
        			SetWheelSpeed(0,2.5,4)
        		Else
        			SetWheelSpeed(0,0,4)
        		End If
        	Else
        		SetWheelSpeed(0,5,5)
        	End If
        ElseIf balik = 1 Then
        	tmpX1 = mobotX - homeX
        	tmpY1 = mobotY - homeY
        	If (tmpX1 < 0.2 And tmpX1 > -0.2) And (tmpY1 < 0.2 And tmpY1 > -0.2) Then
				balik = 0
				berhenti = 1
			ElseIf sensor6 < 0.3 Or sensor5 < 0.7 Then
           		SetWheelSpeed(0,4,0)
        	ElseIf sensor5 > sensor3 Then
        		SetWheelSpeed(0,0,4)
        	Else
        		SetWheelSpeed(0,4.6,5)
        	End If
        End If
        StepForward
        Loop Until berhenti > 0
End Sub
