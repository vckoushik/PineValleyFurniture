
# Pine Valley Furniture
Pine Valley Furniture MVC Web Application

## Importing the database backup( S3G1-PVFDB.bak)
1. Launch Microsoft SQL Server Management Studio (SSMS), which is a graphical tool for managing SQL Server.
2. Connect to the SQL Server instance where you want to import the .bak file.
3. Right-click on the "Databases" node in the Object Explorer, and then select "Restore Database".
4. In the "Restore Database" window, select the "Device" option under the "Source" section.
5. Click the "..." button next to the "Device" field to open the "Select backup devices" window.
6. In the "Select backup devices" window, click the "Add" button to browse and select the .bak file that you want to import.
7. Click "OK" to close the "Select backup devices" window.
8. Back in the "Restore Database" window, you should see the .bak file listed in the "Backup media" section. Select it and click "OK" to close the "Restore Database" window.
9. In the "Restore Database" window, you can optionally specify additional restore options such as the destination database name, file locations, and recovery options.
10. Click "OK" to start the restore process. The .bak file will be imported into the SQL Server




## Running the Application
1. Unzip the S3G1-PVFAPP 
2. Now Open the folder S3G1-PVFAPP
3. Open the S3G1-PVFAPP.sln in Visual Studio
4. Build the Application
5. Now click the run button to RUN the application
