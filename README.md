# web-scraper-C#
C# tool to scrape web applications to generate xml outputs of each category of stocks in the pakistan stock exchange website

##The web scraper consist of 4 customizable folders
##Project Descriptions

**k190146_Q1  (Downloader) **: First one takes url as input and downloads the html file in the specified directory
    Sample Input: k190146_Q1.exe [website_url] [destination_folder/{filename}.html]
    Open the k190146_Q1 solution in visual studio and run the application
![image](https://user-images.githubusercontent.com/37268659/194710115-27721c1c-c978-467e-be7a-7de6eec81289.png)

**k190146_Q2 (Scraper module) **: Takes html file as input in app.config and generate folder from the tables. Generate updated version of xml file for each category of stocks.
  Customize the xpath for the valid path of information
![image](https://user-images.githubusercontent.com/37268659/194710152-136d2f71-fad6-4459-bc93-dd6f96981c0b.png)

**k190146_Q3 (Desktop Viewer Application) **: Extract shares name and current price of each category and display them on WPF application. Each share is displayed within its category.
![image](https://user-images.githubusercontent.com/37268659/194710309-4ea1e9a4-7b37-49d8-88fd-3ec5bac0bd99.png)


**k190146_Q4 (Website Viewer Application) **: Extract shares name and current price of each category and display them on Web interface created using ASP.NET MVC . Each share is displayed within its category.
![image](https://user-images.githubusercontent.com/37268659/194710435-031a68de-537c-47f2-a074-225120e23597.png)

