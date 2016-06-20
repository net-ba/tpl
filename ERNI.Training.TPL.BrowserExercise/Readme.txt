async/await web browser exercise

Goal of the exercise is to implement very simple web browser. After entering URL and hitting Go button the browser displays HTML source code and list of all images on the HTML page. Additionally user can cancel loading by clicking Stop button.

Skeleton of the application is prepared, but you have to implement 2 methods in BrowserViewModel:
- OnGoCommand - the method is executed, when user clicks GO button.
- OnStopCommand the method is executed, when user clicks Stop button.

Implementation cannot block UI.

Task 1:
Implement loading of HTML content and displaying it by setting HtmlContent property. Loading cannot block UI.
Hint: Use HttpClient.GetStringAsync method.

Task 2:
Implement loading of images in HTML page. Get list of image URLs by HtmlProcessor.GetImageUrls method. For each image load bytes using HttpClient. Then create ImageViewModel and add it to Images collection.
Hint: Use HttpClient.GetByteArrayAsync method.

Task 3:
Implement Stop button to stop loading.
Hint: Use CancellationTokenSource and HttpClient.GetAsync method.

Task 4:
Load all images in parallel.
