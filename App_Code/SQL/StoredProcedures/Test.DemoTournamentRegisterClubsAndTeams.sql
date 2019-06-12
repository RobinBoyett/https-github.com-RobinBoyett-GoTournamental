

CREATE PROCEDURE [Test].[DemoTournamentRegisterClubsAndTeams] 
AS

DECLARE @TournamentID			int
DECLARE @ClubID					int
DECLARE @TeamID					int
DECLARE @ContactID				int
DECLARE @UserID					varchar(2000)
DECLARE @GroupID				int

BEGIN

 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'

	-- CREATE CLUBS, TEAMS AND ASSOCIATED CONTACTS
	--// Broad Beech Juniors FC
	SELECT @ClubID = 1

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'wJVEzM74gDk27AErq46Dew==', 'wNgB9/3ZbvXoFDcbFjfhcA==',  'jQYm/oX/xYH6Yq+b6EkTnYLZoOa0ATZGdReYet6X7qA=', 'Tuk+UEl2/I02D4Z1LGa9kvFTZfpQgU3K/cqVV0r2Ye/NtsZ5yaoEiUginO+sA5bZtUCMNT1SKJ5Th8vb5xBb9Q==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 1, NULL, 'Hurricanes', 1, @ContactID, 'false')
	
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'lZiijBt0jocuzGYvP+02lA==', '83ZZbuLZuUwRfJOmuA8pXYNoahppit//dNHb9A30llw=',  'suaEEzRdjTFhsKF93MoVj6oVHhXV9u6fA4a2cJWXPcY=', 'oBxF4/HY5Vq+1YUNGlFeGEoELAq3meDcWifiG6CPf1bf4VQbr2eRvl7FLTC+f9LdOoJSSD1tjRsnUlS5Y2RMmUx2hf1jZZdcOrcWih8ZImA=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 1, NULL, 'Mosquitos', 1, @ContactID, 'false')	
		
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'NF+jy7V4z1+W1prxBxDibA==', 'pceC0CPodbrZrqr7TyAwvrQEbwiwmxyd2JpBXkYN0Lo=',  '2uKbK4bDDaqYBWGhllo0yZ4D80godOYoXlBZzN7/cx4=', 'wsMxINTszNMFO8eOG5fe46izbYx3ZaHbKpcQwziGuE9rscKMbxNg7eWXEEh4udYfKnfivApNrqVOGTw24OHT1Q==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 1, NULL, 'Spitfires', 1, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'frPtXFdNfaWpqPHTjXfXaQ==', 'DkVGoDrfQe71r4/EZfhoAX2Cf0wUF8R9OFOwJdKhly8=',  'fK9t7YJNDZODl2uc2IF1VmdJxtBfmr0rqNZi3mOkj/M=', 'jbBuQe24dAS2DWclqLYXJrevr1C9oDlO/dcTnSDMFwIf+O7tnP1LbAIdbRRUzKeFDSAbc+pNYotWk4DuYxpq5Q==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 1, NULL, 'Tempests', 1, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '2999c4TVHIwRCnr2m+ZSFg==', 'eZ0UKG3HstEJMcgc0QW53Q==',  'g88pguhjkiDbAfGhEKZ5qfCVOZCHEQiXd+TsRpjI0Wo=', 'mCLj08xUMtr/IEu8oqSU2kNp8V3p699jH9963g9h3hb7DJwlykPLK0wm67HeDXWHgzm2kPkW+IEt3CW4ElnQLQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Cossacks', 1, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'etTD+PWl+kqY9RAWXrLCIg==', 'ZzKyyyYLeiyz8aWArya+Tg==',  'DCHtIIinVG1X/fmnAwW8vM101zomAniN+tskzszael0=', '6a6SbjpJLm9sF/kp041IMb2su1ucNt+yoabS+30I6f44+8jyCqm/PpBv5j6C9tPnca3YHPuvBT5UpVIrLt0iAA==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Vikings', 1, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'jHKdNBSJQdyrqk5TGp6YeQ==', 'UUlQ9KcSDNI9cNUs0yBvYQ==',  'HF3GVThT3ZyfBWYl/5Lz3hj6SBhQV8mOt9NFdl5kCqE=', '5GwdhN0opA2E56CcnlYt01f2LzAB2yFAorGgsF6mes2TILS+X4f9HTENrYN8KUU/H3+9/BJus38A5mGjVi6gFQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Corsairs', 1, @ContactID, 'false')		

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'TI2vqWDOYl8ZF1hYUv1nhw==', 'RBnFg1W1XBYhakPLbQHoTg==',  'jQYm/oX/xYH6Yq+b6EkTnfSvePDl1UMvu0HbtbKkcEo=', 'WjhVxU/nK1jZydeFxx4PW626GBJe7dEK+Ov5MmeN17j4nm7PdcDqduKXAYD/zXwTcNsbvVcsP58yZV8hxN9e8A==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Dynamo', 1, @ContactID, 'false')		

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'r9jRSdWjHs4yE/6t2mfe+A==', 'ImMYE2XKnjapMntGnGy0LA==',  '7Qhso7QmV2XnxGZyKWNxRrrappUNI3pZVhif9zE1xy8=', 'hhJaMDmlXYsN3xSkcFRrsNkmwkW7wgrF6bhAZs/GIMDVYKtGXlWOv7Y1wuxLEGIb9MEHmWyGcf6wwigS6k3eKQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Locomotive', 1, @ContactID, 'false')		

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '0OSKGtup3/mnjCb8/IYo8A==', 'zk7wxNie7069ImAxQ8t0cQ==',  'DCHtIIinVG1X/fmnAwW8vOtiPa/NVz+TAP2qVbJb3Ho=', 'snTsJ+uYt5DHS+sWjm1ciwewHCvSUlYlgY6tei17uxjc+86v+82rYyvug63mxwGiJkowuTJ/8Vl0DST6gI9/Ig==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Spartak', 1, @ContactID, 'false')	
	  
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'MFkMuNqAwQtqzNDu0qxKGg==', 'iAwMcG7jh2FHqPesLmHH5w==',  'YWfiFi3jjkKwzmYtykcIfJy+L/F1L7a4dKOAQDHCmAk=', 'uRNUcDPa1wTatLG3v4zugF7MT8MaT/Q9+FTbnl0GkCRaU989lzMfRzWtrifOPJog5X9x5lsTEX1yvit3vpsh4A==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Maestros', 1, @ContactID, 'false')		
		  
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'pAQLX40C3i8qYpLsfKuJcw==', 'sKu+CLe3f066OZ25xHEQdQ==', 'JUu+v1wCxDdU5gjBYfQKvI19aqlEHh46OlmJLTQbx2A=', 'gX5W7eVi23a3raCgvRGNFw0XDdpc+MkZoefan6jEI+MMq5EKgPKlVDd2jKBZa1ZJvbDPZoacKvUg947Z3lAp0g==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Foxes', 1, @ContactID, 'false')	
	
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'Xw2mttwMFeoKKaF3Cdcwog==', 'GPIUSdIo9B0+Q8UgbLgjMA==', '55b6hQaN/2+MwCyNl8pr6iaLrnBa5Vm4SkWOtjfCvV4=', 'uAgYaX4zD6vX+uLAGHIC092MfYbhrO1olJz+TT8U5xSAV2xQkhJNz7quU54B73ySWQdVCL5aYTlww/f9vFp9Xg==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Wolves', 1, @ContactID, 'false')	
 
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 't0xGb+Ov8RdxLJOUBsnaVQ==', 'SUaitFHW3VTxM21W0NADwg==', 'KaZ4uq4k6dBwF2FlZwjUIyNjXqMT82PfHB/hbQqu8As=', 'uzYLSYv0nrdTPZrkkMoeU6Acfdsb4AbBurTcSEfF+vZsDQpOpHywScJT3moj5Yx9j2JJt1RDq/IqNH1DuAQJLw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'City', 1, @ContactID, 'false')		

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'l+pAcmdQcMPuQgq62NVWIA==', '+lvsRfwRBndc//Wndm7ysg==',  '6sIUVRFyd5tArCL/+evURDQ9er9JGFEaQhVKJbMUmF0=', 'itlkWdAjLxSELB4REV+d/C/6PZ29jpPe+erzixHXo5e2n0WOswYqExkYBY0wAEbTA5dHH29Ng+bzBihNnwOutQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'United', 1, @ContactID, 'false')		

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'QS/vtYeQuRMKwz2AU6rt7Q==', 'eZ0UKG3HstEJMcgc0QW53Q==',  'X7FYSSBE5YBHsvANfGdVEGJBj2wW6zK8IxTEUA+fngE=', '0ElArN9xdmkuGz+zzoU1gI+3+JICWjOkm3hFENXw56/3UNE3VEL5ygL6B7khDVOpC9p2ciEibMNSNeC+O+vbWw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Jets', 1, @ContactID, 'false')		

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '50UNzA2sZC177TYmz9RFpw==', 'JIdq1kFz0BCuBaX3olRVwg==',  '55b6hQaN/2+MwCyNl8pr6rxFtGjHpFtnjdSElC3c2uM=', 'ySXPaaMG7ozrGFy0b9BLDKyQyNh2ro5EZruhUMzA/rvbVAwVbt3hqC5XyRgCIYrT0z9jbU5ud7DWIAdXSgAGpQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Sharks', 1, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'gVTJzPLIWsr0KfMeqslpzQ==', 'RgrKU5veOBFekXfozltcfg==',  'hnV18fDze6+TesgXscM+eYwdqT8P/j+Wk6PCbvqaK9U=', '90qXPoG8juc60tgE7i606aobO7BSGA8v9/SLXhPBm5VuHAOLEWuUVIiFClJf6Dkk2tViKr7lsXsfxjt1Wefisg==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Jaguars', 1, @ContactID, 'false')		

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'etTD+PWl+kqY9RAWXrLCIg==', 'wQUTJW/IjKyr3B3umar1Cg==',  'fK9t7YJNDZODl2uc2IF1VqeF7rSjvDfc/dTRipglC9I=', 'RO5xAFykj1kpzfx6sjiI5IByntDeEf7xXlBsua8EhdysKKkpZKUt0Lc2oHgUlq6YXnH09oowcUE9mmKGF186vQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Pumas', 1, @ContactID, 'false')		

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'p6h9cWkh1DQfLu3nZfPtPQ==', 'TR/EheTE06eN+Aot0kOmBQ==',  'DCHtIIinVG1X/fmnAwW8vFJosvaMkp1Q0WuNoRvJvoU=', 'TavNWSe4q4avVxFXsRunquBRRppKswxRUS4FCSV5AgLCnJXchZFydKHCdsmk5GoH8qyoYNeEgugxQvtzTji6+g==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Hawks', 1, @ContactID, 'false')			

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'lZiijBt0jocuzGYvP+02lA==', '+AdPBYP3GIQnheveVwio7A==',  'HQAJ54YVG5GyKQHfUvDd73kYFBwz6tAyvw0aXeDZ/wQ=', 'wpH51YSoOcjcYBq+5OxsujGnOBYJb9tYIHMFP1WKIpdyoh4AfRC5jzdHSeR0URqJygR5My7h697DfMN3TZU2pw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Ravens', 1, @ContactID, 'false')			

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'l+pAcmdQcMPuQgq62NVWIA==', 't6f0y9iKFRL9d9ZtjiGz6z/4Zlh0vKIdupjIpxMB6rs=',  'X7FYSSBE5YBHsvANfGdVEO4+VKguOBG/CsfWT1l7zDQ=', 'wVmnzYZWjDd4GWa/mzHot0NnfLK8o9n7n+ufabzUSv0imkJKh+z54rH8xdXfPy7MQNCLg7S2/jEeqJCFRhXjSw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 10, NULL, 'Lancasters', 1, @ContactID, 'false')			
	
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '0OSKGtup3/mnjCb8/IYo8A==', 'wCnpa2Q6Gl/0zbZ1eNdMgw==',  'BI4R2prnvVSEReEb5Wn/5R0bXgXxmPF5PRCfdx9rXG8=', 'sCPHzhr3Vv+OhpY+0VOVLqOI2UH+MCHp/PIolM1HgzWT3DeDeGGubZRweLdO4Xs+r9g1g4M2c8mKltgcMlvLzw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 10, NULL, 'Mosquitos', 1, @ContactID, 'false')	
	
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'R0V72zDA7cVhusMcHssPPg==', 'JIdq1kFz0BCuBaX3olRVwg==',  'fiqO7EEg/pLWO3CHL7ZHS1J906vLrVxtRvXkYNF8kBE=', 'WDp1VZ906+gTMVvuZCMxHrPp1Dut8tTnRzYOz6M4anR6Z2MtwEIrr5kfEdEvHYwcv/Ep3ospF58dNsSTeJQKCA==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 11, NULL, 'Amazons', 1, @ContactID, 'false')	
	 
	--// Alderhill Rangers
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 3, NULL, 'WoV+pP0DEUoyhBAbpfP3/A==', 'U7Q67rS62WZleR7RJ3yKfSb/L9m/WLLLIzFaUU2ce8E=',  'xA2G2AWdIuBI6Odc2dg+JLXfBSbwO95PZYCq4dVdefo=', '')
 	SELECT @ContactID = @@IDENTITY

	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Alderhill Rangers', 5, 'Maroon', 'SkyBlue', 50, '005622', @ContactID)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'x2DiU2irpii8nIZUS2MHRw==', '1NlCUhuNNJ+0JeGDXubSng==',  '55b6hQaN/2+MwCyNl8pr6kG5tK7z+W/o6jC+KcOwSe8=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Dynamos', 5, @ContactID, 'false')		

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'wJVEzM74gDk27AErq46Dew==', 'QVvVT1p9loSsAULrPagu+g==',  '1wrS5YDuCk7FwTOF8YsH0kL5n5MkMZ0Q5YwCafZqKKk=', 'jrsIeZHsLap+gDIV6MR5wlrsgyu4en0F58/vFbWLhGw7AsO4C2kBLgC5h/TeZ4Ii')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Under 9s', 5, @ContactID, 'false')		

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 't0xGb+Ov8RdxLJOUBsnaVQ==', 'A4CHoKNWiW6nSV718H8/mQ==',  'jQYm/oX/xYH6Yq+b6EkTnaCdPypUnthLJbPaewO3jY4=', 'lQ3ZxSlBQl/v05Z5w5n8blHm8J8mHoYzyPl3YVNt6evaiem7v/eFn2h2S4w25XJnx4122KR6Px6sFVFNMo06+xNllmBPxzCeE6cxkRO+Dfo=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Lions', 5, @ContactID, 'false')		

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '58wgu/007JMRiJl99M1MJA==', 'xFGfPPiuCCghnGqrWarVoQ==',  'YWfiFi3jjkKwzmYtykcIfJKEPL05XeftcvTaFIBRdi8=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Panthers', 5, @ContactID, 'false')		

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'OEu269/ix3EVRBlbASpi3A==', 'sSbOS8rkpfw5+ziY/k6HRw==',  '', 'GmJyt83pBnIwkBPHgWU9cAZm+IuP6zac/6anWRsmk4Ec3qrUW9PkrA1p7BCV1Swq')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'Under 12s', 5, @ContactID, 'false')		
 
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'KQ1ybGawQIrQhX3TSySY7A==', 'XX9tByfzAOiNVOrKBu5FQw==',  'fK9t7YJNDZODl2uc2IF1VggyvYCWKfsvrQ39oXviheg=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Reds', 5, @ContactID, 'false')		
 
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'Otd6unfbduS1M9AWCQtEgw==', 'lzd8e+GVqGxJItS7y7y/MQ==',  'HQAJ54YVG5GyKQHfUvDd704hkbB9hUe4VCIuFwxGeY8=', '1sWzT2KPGO45NLZeiLXHltDRP5Xxg8CkNQU+eMPYId4dwKNXLjQfvoNzOuXPP42+')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Under 15s', 5, @ContactID, 'false')	
		
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'lHkSiKRWO1XHrh1UFesMhw==', 'wY03NrKdqjfe8XxYsoVH4n0nro+utpcIZ2zxvtEpItA=',  '', '43Rwa8sf5O2ciDCHOlqEuJcv6bWWHvTzjqnBdHxX6uAd3yrgH2d3UvWyACiBusTtdjbu31OG/u0eSIMpw5XBEduKkHEZa+DvctL5B4c159g=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 11, NULL, 'Vixens', 5, @ContactID, 'false')	


	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 3, NULL, 'cil8iL0U+mUDLkxlSHSJNg==', 'aBJqvprGqiKCIGsfIySMog==',  NULL, 'Q7S4mCdqqHGdR7IvTYH5e/8+LuQEGD0d4Vbl5XJBKSEFpg/S8D78xLZmex6gJ+n1Vyln9ZDK445fMPUx4+Xzng==')
 	SELECT @ContactID = @@IDENTITY

	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Ashworth Borough', 5, 'Red', 'White', 27, '000655', @ContactID)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'NF+jy7V4z1+W1prxBxDibA==', 'xuLECwaHuC73jCDoqCJRpw==',  '7Qhso7QmV2XnxGZyKWNxRg/NrI91Q+/EErf5DktcHug=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Otters', 5, @ContactID, 'false')		

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '0OSKGtup3/mnjCb8/IYo8A==', 'aJEPGrXVCC/9juoqXFFbzw==',  '1wrS5YDuCk7FwTOF8YsH0iv+7mUU00++6216alC+hDY=', 'qFQ9uAivT6875bUTv7ridYdA19MTYSg6Ac9oFsen+lrQapMJEtrEDAhYGyrCAG1zlNjt/Pip+wEX34UcZ0wgrw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Beavers', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'AD/YSiXgAW+YXJRHZgLKZw==', 'O7BOqLB9i8LMwcjzrfwmng==',  'HF3GVThT3ZyfBWYl/5Lz3h2hUcdrB2r6aGZQOu6m+aY=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Corsairs', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 't0xGb+Ov8RdxLJOUBsnaVQ==', '741ZAJoHF614yEn54i0bzmWTGzWBlWRFEuU8ytCwmUY=',  '', 'Sd/SrFB/8v2BxyFEC8fMvVNxkk+ncrNZvRBWcZxCbhj2b9PJ0LYeWge9BCxWPjxWY5lTcWbl1j20nZhCwUCzIFsmbDAzY4KyQnoyuKLWUVk=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Invicta', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'bipSy/0npjqgirHcq3JiHw==', 'YWWqFn7FQgMFXx9dFbofhM3rvVfId3pxKJQ33+jm1aw=',  'fe0SKgxGC19+UoiMo9TN/fWiARDOu7M0NRAJAnj15yg=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Normans', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'cUjq6s++2IlyY5cRCh+FHg==', 'f/ngplkilTDhlGcm2y/+ow==',  'X7FYSSBE5YBHsvANfGdVEKfaCkJz78DYkD75z9ngnXQ=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'Dynamos', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '2999c4TVHIwRCnr2m+ZSFg==', 'bLL/qCe1tpZAJd6ubOkfIH0C3xU11ws/GreP2CuXtII=',  'cEbv11V3QkHBXShvBxEgGB3HhV8L9K4DXqsF7EDtWYw=', 'dqSJv4C9cfz9OvE2j6o8TILXb3perQRi85HbMTi5vEx8Ax+DzdDmQn2WKQVhuB/i03GianTx/bMDu346jho0Jbib6jBytVyAFYC3Eiv+vW8=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Albion', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '7VdXRTLgR7MjHCJ6v0gcQxqueZ/LYR1kcxAb5f2rnmM=', 'oHcbfQCDtrVnTVvABwQXXw==', 'JuyFFVBGTDIA7cub0vk8xR/4iVyh+BnDiB7LJC/cDbM=', '/HLNbnrqjOxENrIaoAguL+WLV2TI96hHVHftMyG4wWR0ivx6ETILfs8auYEoogNF')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Under 15s', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '5hGCEql8kKmnrgRAAki37w==', 'ZJnthdy7z+zzg8aAL4agYA==',  'xwaj7miaEYlqkgMeSk/KjIYTwOJo+OjVeRCHPWTduUc=', 'z3OiHE1eBGCi2nWpISqePSx0Uuzwb1iD3oeyMvhVBhQwG4J4UGZavmV43J0DzTEA')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 10, NULL, 'Invicta', 5, @ContactID, 'false')	

	--// Brailsford Town
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Brailsford Town', 5, 'Yellow', 'Green', 27, '005776', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'GS08SRyEfthMLqDxeJtmiQ==', 'LchqCPZhyf+3HJxcwfyKVg==',  '', 'qGaok2+yQmaC1uUcppQRrzwkWNXWHywdlyjil/DWgKzgJXhpYcGUQnwl809cyBFg')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Bears', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'R7/niF5lwVW7n7jFIHQYuA==', '5AjznyrPWKQmedG4vaFjjD019niKg63vWAMjg4t4U8g=',  'suaEEzRdjTFhsKF93MoVj0lr9GOyckmvMywLfDMfsE8=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Pumas', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'p/rPlUxLD/vfJoK68G9+bg==', '6JvKs36mR/ygb3rOHg50cg==',  '', 'Xnu+kqoyasxZirDRYasOt21wcZF51N/9aZoJCsl/CISAQgl2SkrRs43GSKfHOEQOEYrggSwtb93noRnBUpE8lw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Snipers', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'sE+4DhrkLQd26jN92snW0Q==', 'thcJjpgozWb/dfvysaDCqYYGNCwkehr2UUYfZk4gjuQ=',  '0PWxBJgvP4vR+8//JBILkW4ssnzyaNexjHypPywOF4g=', '8baSmuW7KwOHYjjEGMoqmCu/AvaRSm/evlrjBkj2YeIeYwL4luVkWZ7JKW2S5YBi5S2YHpPYjGBpb59FjLSiWw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Yellows', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'ya+0UgBWz60NbDo2WGH1QQ==', '5AjznyrPWKQmedG4vaFjjD019niKg63vWAMjg4t4U8g=',  '2uKbK4bDDaqYBWGhllo0ye6xaYMEmx5KSql7QKbw8c4=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Greens', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '3LtSgAJCwYdHopKT4G8Weg==', '6v7YmGUD5hrX09N3wIyaXmFwcQnxUqwpLHV8LhNVJ3s=',  'srVLlNiuDDO1q/SFbsHXWPPD14B9L+yT9ELar1F0514=', 'XS5bsDz7h5eOq0T4yi+Ak/Tm2E/n2ILn8cUAgfnJlucXBtZTHpGx+cv1EQuDulaugdo4l+Yv5p17cPTswFapmQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'Mods', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'ReZFjpNhl0kvTBFt8AjDIw==', 'Sd82UUD6nVLteUZU6ZDjrw==',  '55b6hQaN/2+MwCyNl8pr6ovi/G1KPe1OfWcrmtNh+Eo=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Rams', 5, @ContactID, 'false')	


	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Brancombe', 5, 'Green', 'White', 50, '003936', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'HIyDEz2MA09fxd+OTCrs0A==', 'S+W1v1N4PCHmhCiHF1re8QlP09Vc1pFXPUPAHgd1FRs=', 'CXePyHO/a/TG1Z7/EYOIiW5WgRuCoMSgoOMOP7irH8U=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Celtic', 5, @ContactID, 'false')

	--// Callow Hill
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Callow Hill', 5, 'Blue', 'White', 50, '000987', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'etTD+PWl+kqY9RAWXrLCIg==', 'UT5qv2j4vOl51/ZGnWC79g==',  'RVIDQSX45vQAfWPZlqjw9999rbMx3N0909Monpjk4UI=', 'uNNjjs4UvAPzTfLBUhocigtV9ay6gOXxyqG891vzrd15h8ZDVgaGftF1VnnVvy6HlEVyeZUQj0FIZJOZPE6cSw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Blues', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'YvMXXiibzmEZIgc2AFCeOA==', 'krbxDeF0bu+h0GPx5dZQ/qEw2RLtajhHSFLzxlc8Ibk=',  '', 'ZtBD95n3zfcmgHzhBN5A3HXmtfRKLQ4BRQW+AwOqMwMFS4dcmZb9ixVE9uuvMu8jqwiVs4bJLxWKvjE3JjiPsA==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Blues', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '0OSKGtup3/mnjCb8/IYo8A==', 'vwX4Z2UpoKqHLA7kBT7CDQ==',  '', 'KSLsrQHu1RNTY3FNbi0TJMUEZPRPJuHx/0VWZ4OROH/lXE1Eh02RAghH+/TBWrBK+pQRI+bjdQJX1mBwoFbMVw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'Fusion', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'lZiijBt0jocuzGYvP+02lA==', 'jL9Y7YkSRbOVOzdUdvczBFsnu+F3icTSJvsuJ5lGF4M=',  '', 'szlqVJFepDN/L921WJctZCQWC/7oehTSMhq8wJnwOGIvWLR7czYaNuBX8jpx+MPWUj43gBi5SmNig+1vq62tCPuP3CbTmOZb+Kk0ApVeKD8=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Lightning', 5, @ContactID, 'false')	


	--// Camberhurst
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Camberhurst', 5, 'Red', 'Black', 27, '005463', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'K9za9dPZ0nEn/9eTDIurqg==', 'u42fH5jiriSNTWiDmiNAC93RtqKO2Qsfcbn/+KpZ8xE=', '', 'qzF2zzyXa6WGbDNA43LgDAgceAxOK/xjmuxn/OtNtYZ8J9tL0BAhdOWU2gAr+w5R')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 1, NULL, 'Lynxs', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'x3upFGlu8bp/VHNFyCU28g==', 'sKu+CLe3f066OZ25xHEQdQ==', 'DCHtIIinVG1X/fmnAwW8vHgSDkxAeD+lcbpmo6ZgZ38=', '6ET1yTjsV6TV77m4Q6FQcbibXQI7orIIB2YxF3vIaT2/ZyeCcbZFwmCzP3r5/5ZFsVI5mNcNFZRYHNOdgMi4oNQ8HyPgEKMEpJrYENfCl7w=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 1, NULL, 'Ocelots', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'ya+0UgBWz60NbDo2WGH1QQ==', '+CLe3f066OZ25xHEQdQ==', 'JUu+v1wCxDdU5gjBYfQKvPg7MJrWbwjpQCqSRDevzNw=', 'rW5TjgNqPNQiiqR+upsrmLp9UxWwgCtqso6g0dba37ebOT/tyn7iufRs/UdvKQW0OdhcGufZO+1HvR2TxHJatuybArrNRTHtJ39BkpGjuls=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Fury', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 't0xGb+Ov8RdxLJOUBsnaVQ==', '6NDVzZolpRV2zv64rtcENHa1V2I0HCuBpSvgdr6a6cI=', '7RHfS9qsXqH87ogfdOMgmIR446yJqvzeUyZHx+L70yY=', '180tfvHF3dCQsfe8wuNVmhoDO4Y34ds4lhA3obCl4CL6LdPxPQnzzihVrvqFEDkFc2y2xQsHFJNOShlU4lyF8g==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Cyclones', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'FTq61MSFOmZiOpNZCAfZmA==', 'XX9tByfzAOiNVOrKBu5FQw==', 'fK9t7YJNDZODl2uc2IF1ViyaWkjzW7J6181mRs7mwho=', 'L0EKN4jELMIKVRVl8ipP5AE//UW3eVbsJgwsa55o2gvmOLu1WWR27FOUNvhatnue')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Whirlwinds', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'cyPB/Wcf9zZr07HVRzYxSw==', 'FKHc2Ph/T3e8OZAr3onszA==', '55b6hQaN/2+MwCyNl8pr6iIJwstkXXDBCu5nHeDSbMI=', 'kKHiJTmLE76+tZYc8zQlAD+XuOmr3BRvIv3H9zUN2heKJIMzwFng70TMEj6xuRHk+2XhYG4eNriyAmRXLy8KHA==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Blues', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'CV6Z5jp5vwvD+zTo8tpkIQ==', 'FKHc2Ph/T3e8OZAr3onszA==', '52L56acJmm9Ce/OD+z2GjEssz48vUzWjCoWpLOJcNw8=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Clarets', 5, @ContactID, 'false')	
 	
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'gVTJzPLIWsr0KfMeqslpzQ==', 'vGmQkWoKYLNwr4VxQoMQLQ==', 'y+5ZZZPpS7kjKEx/G0lrVFSqAXijNQBx7jVFRp+yivw=', 'RMPJCHURKXvThhixBflbv8clFWxZ4aHK2AoooRLOqKvco8jTH2AT2sUP4OhZgdbspqAbm1PYJEcN8ZOpuCetvg==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Under 11s', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'TI2vqWDOYl8ZF1hYUv1nhw==', 'nzMYq0yr9mnaHGHjB5PPCvsy2owsglyXR8UpgUu8/Ak=', 'wXN595JsrAyU41QsebV6MEfTDj+JHaquEj3nvrFURK0=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Warriors', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'dzLr5FAfh5tNuRbZDt7crm+mzW5fKmb+mzLlK/m5dyo=', 'jke8bhZZefoG7EHPrytY4cvbSnqZrMAlMs4Y2xkHLBs=', 'X7FYSSBE5YBHsvANfGdVECVRMIwCZ5L5tf6Ofwdmomc=', 'PKMPkQSXkf0UHprOKuTDnukyv4Y2JQ94jyvkg0VhBQZutNu+AaBdh6jn7vn5rt8McUwLb277UWZHfRkw9AIlmQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Flyers', 5, @ContactID, 'false')
	
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '9TeRetStu/D78SLBMvj63A==', 'SOZH7ToeHDgMllaE6rYImm07Ay7gWy/oAJI0b3MskJE=', 'X7FYSSBE5YBHsvANfGdVEA7S+dyNS+iAQt7bcREaUC0=', 'BbboL3XMca//nm9HKNnDQ8jODN9HKFi3PPzFVEsSBBYqXWroiVkGEzVdFKdgoo9qXesG5enY3nzufj1v7lxs7Q==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Under 15s', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'uPyiD4YpoX60g+6L2m79AA==', 'bQ6WJTDRuMslf0cHHuBrqA==', 'O5Hn6/3gEbedhOwCFdirsxzXEV89m/MOPOuGkiZucLs=', 'cpVrAdF82zis1+mCbfMg6eThEbb5F2hVs53pL+nf6HhKhED0jmtrrGQYN+2NoUPS')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 10, NULL, 'Dynamos', 5, @ContactID, 'false')	
  
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Daneston-on-Sea', 4, 'Gold', 'Black', 50, '000675', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'eLmlBFVulOpuNHPBihAJnA==', '38LIeI18E7abyulkzshWczzN+lJzYDhaqFVeBVfhXOs=',  'evSMONiyrbNjEmx+vKhuuT9PtPuKzjRUPQ8+AFtOvn4=', 'puI++hiieAJz9YSCKGv17kcY/epr9MpwoIdOqmbA6Vs56uGrVArZyqYO9T6shcMCGilyM7rHoM2gnYk59lWFDw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 11, NULL, 'Golden Girls', 5, @ContactID, 'false')	

	--// Fanley Harriers
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Fanley Harriers', 5, 'White', 'Black', 27, '007840', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'EDfyx8itRtsuh51ndupmGA==', 'BphalPY7X/nKrtSPHCljbQ==',  '1wrS5YDuCk7FwTOF8YsH0gznEop4V6goOUEbELvuMME=', 'F6CHQJipRmjVprOJCorybqOlEIOqTs0r9pc0omotDGPbXhvddFmBLysdNRHbuWQe2sKsAjTdU+eQSlsMphhLrw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Under 9s', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 't0xGb+Ov8RdxLJOUBsnaVQ==', 'Hhh/TH9iIktnl7KKzznadA==', 'duG6ohtz/8MmkDNbbHphrGGDGLRH1CMSt5Qg7zpCkqM=', 'apc7fsYT9TUelSY0L1WPqA2IOIVeSLNXYFN1CweZ/HH4tMQe7BECn1O1N+/mnmvPeYm3Lu86+IRVGSSvm8Mi2w==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Hawks', 5, @ContactID, 'false')

	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Galesbridge', 4, 'Blue', 'White', 50, '000324', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'VCW0u47Z9a8ZJMD/rJHulw==', 'MsHKUi2jj29jjf2bvBaoZw==', 'RVIDQSX45vQAfWPZlqjw991xhtk+oB9IYPt22srm/lQ=', 'g/seVVZ79GbQEG/D5RFQibGWh3W8ojOkxAkkBUn+sj+6CHTiyIJEIIIlStfvjJktpaSSDeYFWMuS+0HqvfJmvA==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Aztecs', 5, @ContactID, 'false')


	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Hailsford Athletic', 4, 'Red', 'Red', 50, '004251', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '+fKRPILYuaXUua6CviPbWw==', 'u8alNuGTS6ikTmBdy0Qb5g==', 'fK9t7YJNDZODl2uc2IF1Vl7FU62/cDyeIt2XV297aL0=', 'g53MNg2k64DQ3ccKv3wyLLk+dGxEDzWDfFAOgQygG252Ntv/Jri6IoIbj0mN3YBFbXfmlMPs7Iar2B5sKA8dvg==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Saxons', 5, @ContactID, 'false')


	--// High Weald
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'High Weald', 5, 'Red', 'Blue', 50, '000770', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'Otd6unfbduS1M9AWCQtEgw==', 'et8gYjd/9RAHLPkMGDZe+g==', 'DCHtIIinVG1X/fmnAwW8vNtZbweJDfie420PsFe6R4w=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 1, NULL, 'Cobras', 5, @ContactID, 'false')	
	
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'zp4aQ0TMkRKj5OTScy4fJg==', 'McPtnzVMR1/egjnm+dLOTR3qAEQEbfAsiDYS+DjSj+0=', 'D+VR8nrhJP2viNESfTONObG/bfq0vwYDIhXUJJxe4uU=', 'mDPwQIlBBzJ+8IUO5IwMDnGGbHNLDZNFYIYp+uE4Aq0HY/hjEB0CGDN687IA4hoC')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 1, NULL, 'Pythons', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'R0V72zDA7cVhusMcHssPPg==', 'FaaGCavqDXeb1/4IpEPA7FUmKoOFwmqQd/k+TvQs3Ls=', '1wrS5YDuCk7FwTOF8YsH0s2v2BmnzvHbnmpBiJnYLQI=', '9LTVr1UlyUbT50E7rymgDoBEvU+sBWLrVdluGh2nKtTsUXEWIcUrR6cOjuoiKhalHwDpjfOGJWUwdnqQ0MLnGbnUBGP4+NhbLsqUtAo6IXQ=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Dolphins', 5, @ContactID, 'false')	
	
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'cil8iL0U+mUDLkxlSHSJNg==', 'X1gIPx1AIyx5EZIOxIZZ6w==', 'duG6ohtz/8MmkDNbbHphrIakiYJ6A4YLS22OjD9YHps=', 'KUdApMnaa3cPvaBA+xhUBJhKBTxs0k3w208ZGg5RsJ6MB0t96jbLZFfQWrT1lrzA')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Barca', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'kqLIh02XiU4gm+jzvsaWpA==', '5RKDrNjh8CxoE5kCV89wTyE3B2hG4csM2hRG9wT25EA=', 'X7FYSSBE5YBHsvANfGdVELfdj1pOBQQfoUNstawJKNA=', 'vS+sAMrm1pbC48N5GCPEsY231yytAORe1K7NxbDiNZY4Xv9SUIWoYAUHK68nmOmBP6qyzxxZzeuX2jzirapc+Q==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Juve', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '3YbuFYhYFFZO8OHOzHP4zQ==', '2DcNk3nbKRkic6CUy276AQ==', '9j+sOeuwAPem1bopMpjG4j7owWY9fBuZzNQxlPKb17M=', 'UilrRZh/+tg6Yo9XSd7WGNv7IO4Do4Mg65oq0XFg+Wg7kxcbIckiQJfcwwOt34A0')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Scimitars', 5, @ContactID, 'false')	
 
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '2999c4TVHIwRCnr2m+ZSFg==', '0id/Ul6pbSVQaXjBxhHRJQ==', 'kWk3XWjAfuYJ8cVbxjEZrQf87NJvoI3exgA423+IcYw=', 'h3N8hVKF43qd+ygoTvM4+3yxxL6OkMCu2nRZYJn5Qx7cKPbst1TNbZaaB+CANJEV')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Rapiers', 5, @ContactID, 'false')	
   
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'lZiijBt0jocuzGYvP+02lA==', 'HufKCVx5eGVk/Lu9GXyqSIW7+9V6ub0PUb5rfzZ3+6Q=', '', 'YLs15NTj18cEHV0vhhk3swoQz+wl/R2wcqb5KsLi9pEPLYkVZCyLMZGBvYRMKtlh')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'Saracens', 5, @ContactID, 'false')	
   
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'l+pAcmdQcMPuQgq62NVWIA==', 'AI9V3FSddBkkJPfERzXt6m6A8tnL4E0YOros366tsaY=', 'h+UxO0Utbf9Qfl0+bHFFTULzeGUTMS7kGCO1+fdOQOM=', '3aw+FwmFBB/WlxcaC+XAyhV5EOBQveHjfjwtaeWlsOJOMGcT1prcnU8X8ajSpQZSjXZgvU2OZZRMJa7EoOIZvw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Crusaders', 5, @ContactID, 'false')	
     
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'o0QYIXVPmou0nG3URMtFHw==', '1ZuhncKty3pzdLQW30frXhn7oGYjzyf0ezk2e123XVA=', 'Ze8osHtzRaHK1a7VSQuZpGbEIpCZoS5Q74FbSbywo/g=', 'Py0EfoNgNUQmfjuvkxw9HeBz6h89NkjgsD5/rN37eQeF9jF5qtagIGCP75vAZxv/')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Vulcans', 5, @ContactID, 'false')	
     
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '0jugkdmdA8OYDENnNuu9ag==', 'GdopZPH5LiFQfHIZfu6j6Q==', 'hOSgLunb4sbi1sH1TYkbTQb56oBVCCF7+/NDsncLx2E=', 'r59GccQBp7+RMm0EGydvGz2nse0geky4ptTN3ks37u2WTPyjuK3vS0fr3aulVNN+')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Raiders', 5, @ContactID, 'false')	
 
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'VuP6wHE4Y0eilrCGCtmQ5g==', 'V9UjxPKoLg8swe5/peijQQ==', 'TEHkQvHNsARZbZSnbkCJQk55c2txRIj3WJFZgwE9Pjg=', 'pfX7h6zICx88UY2LCtEIc/ByWXmswA9whcvBCefIa1CEKDVi1HTGAgS0DAjMgWaS')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 10, NULL, 'Under 16s', 5, @ContactID, 'false')	
 
	--// Huntsford
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Huntsford Albion', 5, 'Black', 'White', 27, '0003433', NULL)
 	SELECT @ClubID = @@IDENTITY
	
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'l+TDeAbxBwQwhrXEur8w9A==', 'b9dPMUUX5e3yehjdf8VHDg==',  '2uKbK4bDDaqYBWGhllo0yT6ygpEyuh1lSuqAKxdk7ko=', '7hBPQjsjE7K3ElWwXpURJbo1QAMf2qXR5mnPXU/6PWEbdwrs+4oe5lLT6UpYihJ8FI1tAHC7A87FvY9QQiMcxg==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Magpies', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '6xlO0wkc6EyII/VKkC3baw==', 'LET+5lP2s/51JTqh1XEbvA==', '/aMT7gSe9EO40rafhpoBtQkkao3+nO4NePVdo9dOdRU=', 'jHNIi4oEaN/dOkCnqvR/RNvwq+8lhJCWOtugNe7oNBDdHxNi+sMr9LTFkO3/W5HyD9TCGuc5KNBurCbTGi62vw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Phantoms', 5, @ContactID, 'false')

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'Iol3ySyR1S/Y/4xHDkjDHg==', '5iBf1sg8CwzvIOyyGbwB0A==', 'xwaj7miaEYlqkgMeSk/KjA7gpdOMExSl1HXBBdgo2VM=', 'SVkIclcqgicQplpFneNgfMRukAJ/+sDiQfOrgErqKTC7iAOO0VMVK7OHMXRBhb7k')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Magpies', 5, @ContactID, 'false')

	--// Langley Forest
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Langley Forest', 5, 'Green', 'Black', 50, '000899', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'NqVwMYw+il6KPome4gFSqw==', 'B+A3I4lOFg1FlhStmaTw18qpfI0zXJmzCYmmqRurh+E=',  'Wq6h0kUxyCxK/3tZPuQcjLVP1z64wc4Nt33/LpzoiNU=', '0ZhjWpsQYVf4oK8HD7VCUWsHeUczU96QBUp6Kkd2Q80QderfpsNrnySsku+EOGnRQcHEUH/eyvD62bYS0wrBoA==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Foresters', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'K26GJqRWYV3m0Nv+Doo/Yw==', 'JyVTUTupHZ7QZpBstm6PBw==',  '55b6hQaN/2+MwCyNl8pr6qCduKe+4l4v9e1ZfUhMXyk=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Woodmen', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'lZiijBt0jocuzGYvP+02lA==', 'Az+2OMqM61mf+mkuhqA0KQ==', 'zo4LYRqXjBFLBIkd0HxCr197ehomB8j+SKG3q9Q4nZ8=', 'xBdIan/KanfPZGKeN0J9Yl86L76aB1rUBFk0RKbWL6cjIKQwC7TeL4KH0CGrIumX')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 10, NULL, 'Oaks', 5, @ContactID, 'false')

	--// Moston Green
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Moston Green', 5, 'Maroon', 'Orange', 50, '008870', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'WoV+pP0DEUoyhBAbpfP3/A==', 'h2ecomj5NrBzFRTCszf4Ug==',  'fK9t7YJNDZODl2uc2IF1Vv3EXD5qLNr3JfER+wsl+SI=', 'SqqFtld/HUcl2vMraXx/xgOdNsvOa3WMgXxQkNcEIaMJx0baE4LjaiDqupnnjqTK98N+4f5Ua6kDKI+XRGX41A==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Clarets', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '/u973yzmBSrIyGfgTzaQaQ==', '4f/KiDM63MbO3jHEYRIL3g==',  '9j+sOeuwAPem1bopMpjG4mj+9wHl2fzD+H1m1nzhaHc=', 'VqteaOq8gmgeZXgNBa1mSYk5mmi/QkZWmRGcE4D9Iy+725YqIaCPUfpF+wuBgW64oe6K2SspyJ4bsoRUm+Qeig==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Warriors', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'MmMnoIs2MPHA9D/s7v+fetaxN9V6HHT74hSMSEycB2s=', '0id/Ul6pbSVQaXjBxhHRJQ==', 'fK9t7YJNDZODl2uc2IF1VvkIxfusErARM+VjEZzkBbw=', '8qHh7cqpK1kPRIBlbadO6a6HSBpSs9rjms19JGi3jV7y0ksRC6JISnG5tQ8eKsTU')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Hunters', 5, @ContactID, 'false')

	--// North Chesterton
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'North Chesterton', 5, 'Red', 'White', 27, '001112', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'sKu+CLe3f066OZ25xHEQdQ==', 'SUaitFHW3VTxM21W0NADwg==', '52L56acJmm9Ce/OD+z2GjDbzoQ3oGdH5Snwl7L0vqK0=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Barcelona', 5, @ContactID, 'false')	
 
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '0jugkdmdA8OYDENnNuu9ag==', 'Q0KnvK9cF7cogTVxMvt2pA==', 'XLa/B6+tD4N4x3SCYseMTRkNoUrvJuD+wtgL7/DQLX4=', '8yc5gukFoT6rzfet/rjrT8WKSeFXReqKgopegpRBRydDqNg9TeMaA+XQFxJn4FHO')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Munich', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'uPyiD4YpoX60g+6L2m79AA==', '5W5D2+ObJOXDLl5GcxRs0g==', 'rsJVgwZSTs0oWvieE3E6BcRncUYR1+gRl10fn86XZDQ=', 'ME7rd8MYaYsIqwjTJ601F3w4RijlFQhKDxJ69SZ/nb7hNopEyMqEslM9XV4OLbzUYrUw2OtQpV/+0Zh6w0Gh4Q==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Oaks', 5, @ContactID, 'false')	
 
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'K26GJqRWYV3m0Nv+Doo/Yw==', 'PDi0uCauSyRYVsRFw5NooQ==', 'DCHtIIinVG1X/fmnAwW8vLljZC6mP6GVVNEyrpMAH5Y=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Warriors', 5, @ContactID, 'false')	
 
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'l+TDeAbxBwQwhrXEur8w9A==', 'S6JIDOFT2A+DHYnqCNArawdaS9VJPoGD7JYIbEoxgJ4=',  '2uKbK4bDDaqYBWGhllo0yY1OJCfzw+h4ZKd6PXY/7lI=', '9e1NRhFN2qK4OW79kCLgPjMY39Cflc32aSoWH/fNzPYsgFHt8FqolNZWYFJFiPovR5nNOJ9wMgGlZFnZUBAobA==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Robins', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'SINPG3vN+8UQsvCNOgFDrA==', 'AiGCpybB2INhdxYEic3XzA==', 'DVXa60eesveBJtKAUTbU2I7wm7Pts5gma4ORR5ExygA=', 'c1US+kwIBPU2i3bh5LaQH59j3aPrAE/HulMZEAP06huhjkfgLTjS4ICNDjZJtiLO')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Warriors', 5, @ContactID, 'false')
		
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'l+pAcmdQcMPuQgq62NVWIA==', 'AiGCpybB2INhdxYEic3XzA==', '', 'RUFIgpVHupaoQMUbBk5fgrjdCjgu68ic7fq/zdbUWIcEsT4guMg2mB8roFCTA+qd')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Phantoms', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'UMvbwh/C3fU8E9+Fogupjw==', '1munkykeB1F/bi9ojyQi5A==', '9j+sOeuwAPem1bopMpjG4jX6mNrXK522KUEXiLlGCeM=', 'fvEydaU37Edqq/qn46fp2ieMwfVL76l0gVXDHdgUhdBUbH85pROFzOESCCtktHtS')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Invicta', 5, @ContactID, 'false')
	
	--// Oakfield
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Oakfield', 5, 'SkyBlue', 'Blue', 50, '000711', NULL)
 	SELECT @ClubID = @@IDENTITY

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'mYrqxG8eSfZmgpEhw78NqA==', 'J8aQwhOHvVOVkPO75sZ6w12uCH8GKGdQpNkJm2L+97Q=', 'JUu+v1wCxDdU5gjBYfQKvCpSTDHLDq3OkQ1YmZrJIbg=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Larks', 5, @ContactID, 'false')

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '3VdVlC02N0WYkDr/jo9VEg==', 'UUCX4A48YqCzexwnD1ZuiH3DsZEh4zEr6A4N+V9FZgY=', 'duG6ohtz/8MmkDNbbHphrIknBR0ly7kiZpFklx1UsKY=', 'kuJ6TPWz1MXfm9OPHy7h2OdSdQvxcqnwsAVzW7LJhFbTKV1xdvyHtYGxQVWUh96Yf8EI2eL+yT6w6RNHlfH6bjCttDeNdmg/PjbfqXE2+eU=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Linnets', 5, @ContactID, 'false')

	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Ousefield Phoenix', 4, 'Orange', 'White', 50, '007112', NULL)
 	SELECT @ClubID = @@IDENTITY

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'ZeDAGB/9A0B89nZlXylibA==', '/kYpzf1nIppWEzeMw08qD9JBG0LdhfmSKbda/WCaJGc=', 'fe0SKgxGC19+UoiMo9TN/eyopt98sZ2x95qlAuUe91c=', 'jALZVEq8l/3TDYWG35Jn8Xt4Z5nGub/MxLcQMcCBa5DFHIUt8UAZ8EsCxccEwVuR')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Otters', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'Rk6+ckWKuSx/lqMZS0joxQ==', 'D4zg0Eh6ZejVJ/zj5/uIOhgJt8EX5wu7RBXEoMGTgzI=', 'RVIDQSX45vQAfWPZlqjw9wLsFMwaVtDW5FF6vjy1ezA=', 'yk6SG1w8H/MkUI1M6VPZGxxKegpplpG0K9pYTP8pweQ6rMB6rpKv0Vp/zF/GS3Tp')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'United', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'liI42EDAqwAztGTtUPEsnw==', 'qMdXGkFL70ctgNjuNMNu8w==', 'jQYm/oX/xYH6Yq+b6EkTnTHi4pSu9XvCzAGBZ0HackU=', 'X96oszOdYR8hDTwhXl3x6Ozj5Opa8mxg/Ge//T3FPnAiflJ+7dOqlVtMSCLpaIaH')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Eagles', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '2999c4TVHIwRCnr2m+ZSFg==', 'CfYzRQvRZXux/RWXZyQWY+56IXwRd1CMmBWjKrGxhzM=', 'JUu+v1wCxDdU5gjBYfQKvLnF9f/Ov6z0QxZUJvz6NYU=', '9btMU7WznVxMmcFkueFXDQyShCSXGKDPBw2qYD1M80mfi+ngnrz4etBTTljws9RO')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Marauders', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'ya+0UgBWz60NbDo2WGH1QQ==', '43Ps+gHpPWVQoePtqI29TlolAz4qtGD7+uHK8/xMAFc=', '7RHfS9qsXqH87ogfdOMgmIR446yJqvzeUyZHx+L70yY=', 'OS0Kmbl7qHcFN0XvTsTmaEdnCtygK3Yv7adTGP20pfPuQOlBozTKaMM3XErwPDaV')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Vikings', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'g2YxfeOc9elRsubNHG0HlA==', 'gSZYjuV/n8O/Zk9MKxa1UA==', '', 'dzc/gvxlvKnz4LE3eefVIlkKP8J2VIcnFESb7GVs2ldkufKuDmaFP8xj2VqPysgB')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Roma', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'z5WuNy8/aplyCAb0F6qHWQ==', '7cJnIKSiLpSOKB4wdlJ+9bclMxI+ejepvRhmyOhFRIs=',  'XWfHFAyF0Ce8XOT/TASNIOVrU6zrZrrHq9FprUyBdbs=', 'vTCCE0gFbZqifix03harZyWIZckwF4YXcil4mdNTsMqZlhoKkOiI2gDudMbWEz54MwHIfG1Hujey33kOBb3Drg==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Lazio', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'U2kR3lt1WEaPX2pd1ePrjw==', 'LswV514Ki3ZLDRh4uuj2Lw==', '5rZAhnkqf1IMG6/EJP+YDI/+mHwHwTjAFr2/X7LVn2E=', 'GPN6FxiUQhqjbL4YrS2p2oqUHbzIGCXX7PPpdF2APOM/W8gHM2SPF4O8I1bbI7oCjVMDJ89n1hobJcLOsnFQ9JBBAyyoV1UvwdnUU2xzVg0=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 10, NULL, 'Vipers', 5, @ContactID, 'false')



	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Palesford North End', 4, 'White', 'White', 27, '001229', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 't0xGb+Ov8RdxLJOUBsnaVQ==', 'KOoOD+AQVjSCtJ04R6dTwg==',  '2uKbK4bDDaqYBWGhllo0ycKZw2lQsTL/1GerpN55Kic=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'Bears', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'pMjwYngg6RxiwDXGYZCgDA==', 'MzcHxveZJJh+6DyEx3qOfw==', 'JUu+v1wCxDdU5gjBYfQKvJHyEseeJojLx/wEAF/wmLo=', 'Z15kVEJjNKueIP2AlGmLwNyGve2cU9x00bPk3xpDipZb1JixsaptB5anxe61HQnb2Uuwagpq+lc3tMgzRDfkZA==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 10, NULL, 'Madrid', 5, @ContactID, 'false')


	--// Petershill
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Petershill', 5, 'Blue', 'White', 50, '012200', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '8XHcFNugyCaYm5AQ6P2thw==', '8Dkg3ML6SixPYOpQS+WOYtxQ29DLuLXAt89JjjTgHW4=', '55b6hQaN/2+MwCyNl8pr6jKtHuIocWkOoYHuUPzASdQ=', 'Tg3+x8gQjPgDDqeQZol6iHEABCdh/A6v1gcY1l0BSCtxfb9Rd5EEEpWbLEyHSSeVArLBHQI61ZFVG1EmI7XxlIThd9+EdggOSSycn9n15UQ=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'Blues', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '/UtykmcFxpczOrNNqVvYlg==', 'SNqPPYmySTe3AwV05+cBSg==', '6sIUVRFyd5tArCL/+evURDG5ZuCTAWK4KWu/I7hRjh8=', '2bkN9zKUX+ReCJvBAxt8Z3LBSejMPIpCmP9cEDvzWep4CeH98OBrVOnru7Rd6QlJDrJJSjqyx4XLKlm45Hy6LA==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Nomads', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'vSapYFuMJsu8+ibUkNgEmg==', 'OeasTg5W7Yc2AYAMBAffFg==',  'CXePyHO/a/TG1Z7/EYOIiYXMxskwpEJd/J4TD7reVHA=', 'uU5Ya7QtA2lMDqnSFaMmc0xZerbxFGROeWz0CNra87G9cEja6f8cxNpDWL/gqsUu')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Bluebirds', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'CQYxUlPuueecem1izPtcIg==', 'pwzVKFUosq80t2F3shMcqk9REQ+9mm/wJ7HkD0K7lTM=',  'suaEEzRdjTFhsKF93MoVj5GAyxaA8fpHvhniyyC8oBM=', 'SfyRH4oehg6uUyh7yOTY3z6DxjnsGtfXV2/ofKEh1teC36WFbQdpcvN6AWl1A1YT')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Azurri', 5, @ContactID, 'false')


	--// Princes Park
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Princes Park', 5, 'White', 'MidnightBlue', 27, '000337', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '0OSKGtup3/mnjCb8/IYo8A==', 'JSFAb4FshlGA08iVXzZOeflSEkXeNqPFTjiBi9d40QA=', 'CXePyHO/a/TG1Z7/EYOIiW3kTmrhAa3RSVu9clkvRt8=', 'rhxc9KyJRH4swxUREKFlPaA4h9dYeU/P647FJHjeT4KV122VQe1vGYpGj6RUI6nKvU6XU1tdI7BYYAdRcHrBzQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Jedi', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'cil8iL0U+mUDLkxlSHSJNg==', 'z8KKWfvRC4DTGd1WfHFUJ69Xtw7nKQiTofisu3xzu7g=',  'xwaj7miaEYlqkgMeSk/KjAeFwE/Qj3a1PX4aILK77zI=', 'MxN+o4PgajGnSh8NQP2RETKxeX69OdxH7F4cYpltoZQ4GQafDydub5IBfJJNOTUCjW7h5QF7uorT7nAtjqC5Bg==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Spurs', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'qZcCl/6Yp3F8oIciTv/uqA==', '/kYpzf1nIppWEzeMw08qD9JBG0LdhfmSKbda/WCaJGc=',  '9j+sOeuwAPem1bopMpjG4ltrJFLgfICNF+X55stbBBY=', 'iHV5cSvRNrFfUK2jCeXrpSavKzQWcBQQtQgB+Obne3wC144LkGdd7kJtCYRMqYEpzOsENIUC9ZYl0ltL3g1kmsbIJmSJB20SlS4QrH3vY6U=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Princes', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'nZYvtNh9JBmlbeN7BFo35w==', '2/ey/wQkePoX9vnIgdyeN1kF9dQrdm5WpUQ9+7AJfe0=', 'HQAJ54YVG5GyKQHfUvDd7057/dXHYkRmDhzm0HM+yDM=', 'e0/WX2CPPvcq2JlVFsOfviiIGmaem9iZJR8OVYxiQRrb+YDT8PTR7BgFNcIzyOsZzaefd8B3m4MQjyeit52ncQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 10, NULL, 'Under 16s', 5, @ContactID, 'false')

	--// Rainsfird Town
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Rainsford Town', 5, 'Red', 'Red', 27, '004001', NULL)
 	SELECT @ClubID = @@IDENTITY
 
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'XFmATE8Y6Hrt9mTkCVpBSg==', '6xlO0wkc6EyII/VKkC3baw==',  'fe0SKgxGC19+UoiMo9TN/dxKLgpFMwQUN6H5JP6K5U8=', 'O8LhjEYKJx5X/PPncwWPYynk/OnkEkvTwJetRfTR95wZf0st4lk7CImihH5mgCnX')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Ferraris', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'etTD+PWl+kqY9RAWXrLCIg==', 'WHeoF3m1XyR69AEchuSNj3SXCHkSNa1b+HmLUO9rsF0=',  'DCHtIIinVG1X/fmnAwW8vIbyLlUV0RHxycZF8fOkfOc=', '/KVRv83m0AFTFpqglMsgyAeKqXs4klgQL/PMfZqJh8PR6kf2pBABnff9RwtDBYFo')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Bugatis', 5, @ContactID, 'false')	

	--//Sailsfleet 96
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Sailsfleet ''96', 5, 'Yellow', 'Black', 50, '005330', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '9TeRetStu/D78SLBMvj63A==', 'Sk5jb0HKpR1mUtGBqQ2sHQ==', 'fe0SKgxGC19+UoiMo9TN/Ui4244sx8BdGvtAgD3g0jo=', 'J3AF1NsVgACK34SyVgw2o5eREnMqA35oMWRvlgFQNsvRChOXamTCQ/DDwDKKdWRmp0q+Y/CV4Hm2C2dqQ4UAOg==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Lasers', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'Xw2mttwMFeoKKaF3Cdcwog==', 'et8gYjd/9RAHLPkMGDZe+g==', 'DCHtIIinVG1X/fmnAwW8vKzzSsEFoEC/j3TgOJwhba4=', 'sCa2TgPYmTr+HPTKKFDXgdrFJlC0hwLeTIXP4qVICT9FEp5EOXcpnzK2pp+uyZeG')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Spartans', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '+qr7RUY8MisOMrtzlNpEKQ==', 'XeeFthAQQh96qyyt7sEbmvSbGwXSKa14FTeDrkQyNz4=', 'duG6ohtz/8MmkDNbbHphrE4bfIq7YNsRFB7ROo7saqc=', 'CcWgs442ibQdn9TYoGdJ9jifWNdOPpVnECnZh4PGRt03bkDD7dW97Ou0iQHF5ev3bsLKCk5wySYnxS8uUe7HrA==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Trojans', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'vul2VnlifpadxovEbkOQqw==', 'djJ1rDaG3ZMTvM+yrfTrxTdj7+tv/abf90wulY0mn6g=', 'Ze8osHtzRaHK1a7VSQuZpD08V0UXrQ7wOgRRo7/pmKs=', 'iRTOhhSehRPjokpzlP9Uvgxte6lJnrwNzkvsDH6gsl6AEWnYCqUoVdzA9H65nCnB+JN0tg268foZu6wIO1PapQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'Bulldogs', 5, @ContactID, 'false')

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'ayGcgvu62bZYbRW5MaADVQ==', '4UOPQ0oaNFnK69/YOp97Mg==',  '55b6hQaN/2+MwCyNl8pr6lyMPSPMpoDgaPc5LbI6RLY=', 'hhiYDwQGz3zhSP9i1VhWrt54i3mrf1XZHBq3VweS7Rm9UZ+NucSP4ByNCK04i1R7NHadUosBvYGvowGgnj86pA==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Bucaneers', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'lyPR8xArDmpWpPhcDLVlmg==', 'HdJJCRX6DzGB79ieHuGmIw==', '9j+sOeuwAPem1bopMpjG4vgdeeer2Te449b8jRVNdPQ=', '+E/r76PkCWaytMkc8bFn6e8LzY4ORG0va3h7pP/vdqTI1wYIaIz/uL6vWdhFOcZOfL8Sojsk9rSP16gFhUh76g==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Yellows', 5, @ContactID, 'false')

	--// Siddenhurst
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Siddenhurst', 5, 'Blue', 'Blue', 50, '000449', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '50UNzA2sZC177TYmz9RFpw==', 'BGxrBSWoniEUL1Pyg2gDI26c/MquMfgyJnbsL2OyQfI=',  '6sIUVRFyd5tArCL/+evURIYWRC7rhtIbZKS0drevKFs=', '9q9pvix2JSOhYSCAqr+zaOeRH54V0Az/qdrbFE14puH4JRbZUJm4qNiU0V86QhJFyL+bDTqi3CT1x1DUuLbwPw==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Marauders', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'TI2vqWDOYl8ZF1hYUv1nhw==', 'yN4uO4nyi0g4XeTy4lpa1g==',  'CXePyHO/a/TG1Z7/EYOIiTmC5eA46UGlZqTuBnGkYv8=', 'Hh5ftodi36Xyf53lP1I+Xx3NvEzc0DPWP9XPz5yjc5xHLRVErspinzmUxul/mb41ScwxP4LeZ+zCfNPZjve4oQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 11, NULL, 'Bluebells', 5, @ContactID, 'false')	

	--// Stellingford
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Stellingford', 5, 'Red', 'Black', 50, '011888', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'pAQLX40C3i8qYpLsfKuJcw==', 'GPIUSdIo9B0+Q8UgbLgjMA==',  'CXePyHO/a/TG1Z7/EYOIichCR5YBOAPyIZsdBJRaVDk=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'Cardinals', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'D5MZbWhPVJIn7L15IyTWMA==', 'sCW+afK2yv3rEHPjU318PA==', 'xwaj7miaEYlqkgMeSk/KjNbGRlimeKbaRaZvFHE6Wos=', 'XPGBRgBOhJ2P9r4nPw54Us6lM9g+nTvgMkNg32+aMUTrqp+ZZKbihbDgHop2qmtjUAu11Hyt1AUpg2dPUjr9IX2M8C3Hgkug/E+88pdg7+U=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 10, NULL, 'Imps', 5, @ContactID, 'false')

	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Talescombe', 4, 'Red', 'White', 50, '004997', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'QS/vtYeQuRMKwz2AU6rt7Q==', 'EdmhBWck11UWdpgrL/yKKg==',  '7Qhso7QmV2XnxGZyKWNxRpxLgTH8AX1jQa40Pbo3GHE=', '7Bn9gpG3wQGyddFzfIhFdrdbwLjIZ8uH0iycVALuthRYoeyq3c/XeYdZ6heDlC/n')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Seasiders', 5, @ContactID, 'false')

	--//Turners Oast
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Turners Oast', 5, 'Lime', 'Black', 50, '000901', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'TI2vqWDOYl8ZF1hYUv1nhw==', 'ldFv7CdWFgh1qi1/bS2xMQS2gAP0GUCjTkzxmcGbooU=', 'jMAD6cw7edWjihKoepOS8n878EMQbAZqnpEZQQqcmXw=', 'D1oB7KjlQehnyyOIDldt6qNcotyuIoA/F+bPiFwvXWg2qpJQHIvnm8J06O87zKH4')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 1, NULL, 'Under 7s', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'ya+0UgBWz60NbDo2WGH1QQ==', '1GdL65CT1kOEqlQlIb7xpg==', 'DCHtIIinVG1X/fmnAwW8vB6UGfhwmrBsVna/ZV1P8fI=', 'gcoyInkk5FKD+EzoNupcyM/33VzzQqle+Can3ZC+oYYYG3msf22f8HypXmfj/9jB')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Blacks', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'uBsU5G+mGny2Y7aNHFSpwg==', 'nHhPzQW4GRo/8SZOZYfwT0K1Zod2VwDfRELS6BtDL7Q=', '6sIUVRFyd5tArCL/+evURH5leJ6xWQRdeea0sE8dO/4=', 'e292ZqIGabkSjWRdVK2xzT/ArzMkMbfenx65Zegzujxh+THQdU91mP9BQeHxQsLm')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 2, NULL, 'Greens', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'Xw2mttwMFeoKKaF3Cdcwog==', 'E3+yJ0s/GYAGxVv1r64jNg==', 'qUf9b1jm+yT+wb/sRt4t392xBY+AiNaohJ/7Bc29HL4=', 'jqRNMoRCQQXFxP7XJawhz3nfIr1GhIPOd8qILPVQoiPBGQIoPExlDRXFNX9gKir5')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Ferraris', 5, @ContactID, 'false')

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'kqLIh02XiU4gm+jzvsaWpA==', 'g+D7Bb3tjaTN/9sVhZetTQ==', 'duG6ohtz/8MmkDNbbHphrPZQa3qXGU5p6Gg12aYRkW4=', 'xWHq97MXcvF6mFMyH+ATcvH4TJudapfcSR2sq3jlN+rjcjeVhV2+vI7NT2TEtQXr')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Under 13s', 5, @ContactID, 'false')

  

	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'West Berwick', 4, 'White', 'White', 50, '004445', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'pAzd/j3Kv87a0Sxy4UdaTA==', 'RBnFg1W1XBYhakPLbQHoTg==', 'fK9t7YJNDZODl2uc2IF1Vl7FU62/cDyeIt2XV297aL0=', 'RmLjFbQMvebdg8a0qTYzpekn01JmCDnHgvn7p5HK0xVGyELGFOt9pbT9CQ1wmdKIlRAdFxPqSn/CWskdU0UTBQ==')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Phantoms', 5, @ContactID, 'false')



	--// Wheatswell
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Wheatswell Old Vic', 5, 'Red', 'White', 27, '000776', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'lZiijBt0jocuzGYvP+02lA==', 'uVs2U2iDcvO7aI1r6mWDzQ==',  'CXePyHO/a/TG1Z7/EYOIibHNR1WRZepFHWNF74saQhk=', 'jRGEFybNyrJlwK3xDeH8kK5xOCHI6M4YMcb64nRB46bXIwWCoNCWR9A1o4DNB9T2')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 6, NULL, 'Goblins', 5, @ContactID, 'false')

	--// Wroughtley
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Wroughtley', 4, 'Red', 'White', 27, '005330', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'O0h7+57utNDNMfwhP5Me0g==', '4SDFTseG2vnnxzG/tl0bcU6uKIBA6hlRY2f7WYbk06M=', 'X7FYSSBE5YBHsvANfGdVEPKzCf5UnSKCBHtdNxpg57s=', 'VvXZpVs9CSgxdFIs/zJGpsFMB2oMbl7f1IYto4TTdQZXs86FxEftkJ+o/VtfyaNem6UMHX0hZlzDxrqcCT/3yF5JEFJVKPq22MHg7Ig7MII=')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 7, NULL, 'Vikings', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'bNI6a+AgcwR+9W5JXhaUkQ==', 'mEm+wl2kQFoF/8zcfsx6KQ==',  'fK9t7YJNDZODl2uc2IF1VthQu+aOUxC2HFuqP5vmSTY=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 8, NULL, 'Tornados', 5, @ContactID, 'false')


	--// Youngs Ghyll
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Youngs Ghyll', 5, 'White', 'Black', 50, '005388', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '50UNzA2sZC177TYmz9RFpw==', 'eCXfGV3ZvaYFNyjhmVh8Lni/UpOpGMLqUfpMy9nTKBw=', '55b6hQaN/2+MwCyNl8pr6jR5sCkgk0bBzODrMhtCtc8=', 'SqVgIhdBCpzE3n9XGUXyV3rFEqn4L6FNnjJAVV7Zg9E78311mS0zy9oS5+bfAi5I')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 1, NULL, 'Magpies', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'v+N5FjA2mQw+1Pi+BOlQtQ==', 'JMvquRaBHM+xLI4Xx1eXpg==', 'xwaj7miaEYlqkgMeSk/KjLfjSFQFgBLRvOOH7QrcULA=', 'N8xocQeiXxqeZ4VHuTju9h9u6vpLl5+jxfLF/l88BudVGrNKwxQmro3PfNUvrxKS')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 3, NULL, 'Magpies', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'etTD+PWl+kqY9RAWXrLCIg==', 'uPyiD4YpoX60g+6L2m79AA==', '', 'm6jrkUBWSwitc2LxcboOY6sgnF3R4ZQhq/U6beKNlFVt8jxeiyVn+8OU0JVLrZYD')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 4, NULL, 'Raptors', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'z5WuNy8/aplyCAb0F6qHWQ==', '+RjiAMmtdglAq0PqeOlQhUFf5ZR3ew6F1+saFFLRko0=', '9j+sOeuwAPem1bopMpjG4j7owWY9fBuZzNQxlPKb17M=', '+lolqR2RBAhgOG0grX6jrVunbgCKgBlbvSBjR3psfiL8br/NjUQmhIU1B+fcwuCX')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 5, NULL, 'Saxons', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'l+pAcmdQcMPuQgq62NVWIA==', 'A1TSOBYhqGVZha5vH9ue0g==', 'DCHtIIinVG1X/fmnAwW8vM101zomAniN+tskzszael0=', 'tCTMX8xcTB1OFt0A/8B2cSSJP4DyAUrltGpKiIa4HaW8e3DLEOcxpGtS6RoqMxCM')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 9, NULL, 'Under 15s', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'EDfyx8itRtsuh51ndupmGA==', 'n+dH7N9Bti5wq28kHLvdsw==', 'DCHtIIinVG1X/fmnAwW8vMkZHzE/RDa2IqmVaXTNZis=', '3vTpAw0v2EsWOHygRh6mPzy/oFbKdLzYkURI/G/qvlamemrjvcMJlFtvKe9Wghwi')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (@ClubID, 11, NULL, 'Ladies', 5, @ContactID, 'false')




	--// Supplementary teams for 4 groups in Under 11's
	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'Xw2mttwMFeoKKaF3Cdcwog==', 'l8lBSC0EkbzVPRnx63zbkA==',  'bQOwd8k1SyvsbdHb0Wt5BRjGqaYqnit+Fk5CjduHo4w=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (9, 5, NULL, 'Ospreys', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'x3upFGlu8bp/VHNFyCU28g==', 'gOtHampdmhtnmg8IiZeCWQ==', '', '3YEFWKBbAf9kzMpZPNiGp6nHddk7B9BJKm5JAyiVNu5oCiyIXHWhk5wFN5/4lW7C')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (17, 5, NULL, 'Lapwings', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '0i9ibLtTwL9Uw4Iym+2a8w==', 'lnOPPei6Of1WfInwW/TSbw==', '+Z0kvOz+g8BOhC0RJ4UVCykBtb4r+WDbr4x2HvQF0UA=', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (20, 5, NULL, 'Wanderers', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '7lcGPAPj/usNyK4sC5XUDg==', 'XXEL6RWEejMivygRpeVTTQ==', '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (23, 5, NULL, 'Hornets', 5, @ContactID, 'false')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, 'l+pAcmdQcMPuQgq62NVWIA==', 'uVs2U2iDcvO7aI1r6mWDzQ==',  'ZrcGlkSwAPVjYBkLdQ7W4jti9U0yI6l10YJiDbPqhn4=', 'o65Rbs4cZCHMixoMRVit9HL9aD2Bg6bOifunAQbJZuYb8dywFWEVjdqcFOlkf5wU')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (29, 5, NULL, 'Tigers', 5, @ContactID, 'false')



	-- supplementary teams for U 16s
 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (1, 10, NULL, 'Wellingtons', 1, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (1, 10, NULL, 'Halifaxes', 1, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (1, 10, NULL, 'Lysanders', 1, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (5, 10, NULL, 'Cossacks', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (7, 10, NULL, 'Hawks', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (7, 10, NULL, 'Ravens', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (11, 10, NULL, 'Tigers', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (11, 10, NULL, 'Lions', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (15, 10, NULL, 'Racers', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (16, 10, NULL, 'Under 16s', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (19, 10, NULL, 'Vikings', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (20, 10, NULL, 'Psychos', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (26, 10, NULL, 'Harlequins', 5, @ContactID, 'false')	

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (26, 10, NULL, 'Saracens', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (26, 10, NULL, 'Barbarians', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (27, 10, NULL, 'Impalas', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (27, 10, NULL, 'Ellands', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (31, 10, NULL, 'Bluebirds', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (34, 10, NULL, 'Ozone', 5, @ContactID, 'false')	

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 4, NULL, '', '',  '', '')
 	SELECT @ContactID = @@IDENTITY
	INSERT INTO Planner.Teams (ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered)
	VALUES (34, 10, NULL, 'Lightning', 5, @ContactID, 'false')	

END