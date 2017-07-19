

CREATE PROCEDURE [Test].[DemoTournamentSponsorsAndAdvertsCreate] 
AS

DECLARE @TournamentID			int

BEGIN


	--// CREATE GT SPONSORS
 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'Cancer Research UK', 'https://www.cancerresearchuk.org/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'British Heart Foundation', 'https://www.bhf.org.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'Save The Children', 'http://www.savethechildren.org.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'Unicef', 'https://www.unicef.org.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'Childline', 'https://www.childline.org.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'Great Ormond Street Hospital', 'http://www.gosh.org/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'BBC Children In Need', 'http://www.bbc.co.uk/corporate2/childreninneed')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'WWF', 'https://www.worldwildlife.org/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'RNLI', 'https://rnli.org/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'National Trust', 'https://www.nationaltrust.org.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'Woodland Trust', 'https://www.woodlandtrust.org.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'RSPB', 'https://www.rspb.org.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'RBL', 'http://www.britishlegion.org.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'Age UK', 'http://www.ageuk.org.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (NULL, 'Cross Krav Maga', 'http://www.crosskravmaga.co.uk/')


	--// CREATE GT ADVERTS
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (1, N'CancerResearchUK_1', 2, 1, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (1, N'CancerResearchUK_4', 1, 4, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (2, N'BritishHeartFoundation_3', 1, 3, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (3, N'SaveTheChildren_4', 1, 4, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (4, N'Unicef_4', 1, 4, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (5, N'Childline_1', 1, 1, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (6, N'GreatOrmondStreetHospital_1', 1, 1, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (7, N'BBCChildrenInNeed_1', 1, 1, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (8, N'WWF_3', 1, 3, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (9, N'RNLI_1', 1, 1, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (10, N'NationalTrust_3', 1, 3, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (11, N'WoodlandTrust_1', 1, 1, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (12, N'RSPB_3', 1, 3, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (13, N'RBL_3', 1, 3, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (13, N'RBL_31', 1, 1, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (14, N'CrossKravMaga_1', 2, 1, 0)


	--// CREATE TOURNAMENT SPONSORS
 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Allard Creatives', '')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Allard Double Glazing', 'http://www.allarddoubleglazing.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Baldwin Plastering', 'http://www.baldwinplastering.com/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Boars Head Golf Centre', 'http://www.boarsheadgolfcentre.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Bunnyrun Childcare', 'http://www.bunnyrunchildcare.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Burgess Management Consultants', 'http://burgessgroup.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Business Manager Direct', 'http://www.businessmanagerdirect.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'CG Cars', 'http://crowborough-vwaudi.co.uk/about-us.html')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Coltsford Mill Wedding Venue', 'http://www.coltsfordmill-weddings.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Complete Print Group', 'http://www.cpg-net.co.uk/page.aspx/Home')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Coppard Plant Hire', 'https://www.coppard.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Ecology Solutions', '')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Green Rose Design', 'http://www.greenrosedesign.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Holman Plastering', '')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Image Digital', 'http://www.image-digital.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Intersport Lewes', 'http://www.intersport.co.uk/en/stores/lewes-intersport-of-lewes-s10134')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Lifestyle Ford', 'http://www.lifestyleeurope.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Luke Turner Plastering', 'http://www.luketurnerplastering.com/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Mid Sussex Timber', 'http://www.mstc.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Miles Private Hire', '')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Phillips Mans Shops', 'http://www.phillips-mans-shops.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Print IT Digital', '')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Protect Rapairs', '')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Race Interiors', 'http://www.raceinteriors.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Realignment Osteopathy', 'http://www.realignment.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Redwing Roofing', 'http://www.redwingroofing.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Rob Godfrey Tyres', 'http://www.godfreyautorepairs.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Shane Corby', '')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'SouthEastCamperHire', 'http://www.southeastcamperhire.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Sussex Business Coach', '')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Sussex Timber Products Ltd', 'http://www.timberbuildings.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Tester & Jones', 'http://www.testerandjones.co.uk/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Wells Associates (Accountants)', 'http://www.wellsassociates.com/')
	INSERT INTO [Planner].[Advertisers] (TournamentID, AdvertiserName, WebsiteURL) VALUES (@TournamentID, 'Wych Cross Garden Centre', 'http://www.wychcross.co.uk/')
	
	
	--// CREATE TOURNAMENT ADVERTS
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (4, N'BoarsHeadGolfCentre_2', 1, 2, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (11, N'CoppardPlantHire_2', 1, 2, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (18, N'LukeTurnerPlastering_2', 1, 2, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (11, N'CoppardPlantHire_4', 1, 4, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (8, N'CGCars_4', 1, 4, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (31, N'SussexTimberProductsLtd_4', 1, 4, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (7, N'BusinessManagerDirect_1', 1, 1, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (34, N'WychCrossGardenCentre_1', 1, 1, 0)
	INSERT INTO [Planner].[Adverts] ([AdvertiserID], [GraphicFileName], [GraphicFileType], [GraphicStyle], [ClicksThrough]) VALUES (33, N'WellsAssociates(Accountants)_1', 1, 1, 0)


END