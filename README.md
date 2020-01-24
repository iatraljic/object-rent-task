****************UPUTE ZA POKRETANJE****************

	1. klonirati repozitorij
	2. otvoriti repozitorij u terminalu 
	2. cd backTStask
	3. promijeniti pristupne podatke u backTStask.csproj file-u appsettings.json
		      "ConnectionString": "Server=(local);Database=[imeVaseBaze];User Id=[vasId];Password=[vasPass];"
	4. nazad na terminal
	6. dotnet build
	7. ukucati komandu dotnet-ef migrations add imeMigracije
	8. komand dotnet-ef database update
	9. dotnet run za pokretanje servera
	10. cd ..
	11. cd fronttstask
	12. npm install
	13. npm start
	14. u browseru upisati http://localhost:3000	


