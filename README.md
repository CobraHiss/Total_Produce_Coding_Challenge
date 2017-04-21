## Introduction

This was a pre-interview coding challenge given by **Total Produce Limited** as part of the recruitment process for a software developer position with the company.

## Challenge

Create a sample WPF Application (using the MVVM design pattern) with a grid that shows and updates data.

 

The WPF Application will show data in a DevExpress Grid (A free trial and sample source code from here https://www.devexpress.com/Products/NET/Controls/WPF/demos.xml).

The data will be consumed via a WCF Service call initiated by a button or on the open of the application – the DevExpress Grid will also allow editing on the row update.


The WCF Service will also expose Insert /Update/Delete service calls that will take the edited/inserted values and send them back to the data store updating/inserting the data.

 

The data source can be SQL Server, XML, a text file, or another source.