﻿// Thank you chat gpt 
    // Array of background images
    const backgroundImages = [

     'Images/Images2.jpg',
     'Images/Images3.jpg',
     'Images/Images1.jpg'
    ];

    // Function to rotate background images
    function rotateBackgroundImages() {
        let currentIndex = 0;

        setInterval(() => {
        document.body.style.backgroundImage = `url('${backgroundImages[currentIndex]}')`;
    currentIndex = (currentIndex + 1) % backgroundImages.length;
        }, 3000); // Change background image every 3 seconds (adjust as needed)
    }

if (window.location.pathname === '/') {
    rotateBackgroundImages();
}
if (window.location.pathname === "/RoomsAndSuits" ||
    window.location.pathname === "/Authentication" ||
    window.location.pathname === "/Contact" 
 // add forgot password aswell here and signup. 
)  {
    // Change background image
    document.body.style.backgroundImage = "url(Images/suitsbg.jpg)";
}


