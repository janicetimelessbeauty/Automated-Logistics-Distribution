
let videoBtn = document.querySelectorAll('.vid-btn');
let searchValue = document.querySelector('.search-field');
function filter(sort, column) {
    console.log(column);
    if (sort == 'ascending' && column == 'productname') {
        window.location.href = "https://auto-logistics-distribute.azurewebsites.net/Home/Filter?sortBy=productname&isAscending=true&pageNumber=1&pageSize=10#packages";
    }
    else if (sort == 'ascending' && column == 'productprice') {
        window.location.href = "https://auto-logistics-distribute.azurewebsites.net/Home/Filter?sortBy=productprice&isAscending=true&pageNumber=1&pageSize=10#packages";
    }
    else if (sort == 'descending' && column == 'productname') {
        window.location.href = "https://auto-logistics-distribute.azurewebsites.net/Home/Filter?sortBy=productname&isAscending=false&pageNumber=1&pageSize=10#packages";
    }
    else {
        window.location.href = "https://auto-logistics-distribute.azurewebsites.net/Home/Filter?sortBy=productprice&isAscending=false&pageNumber=1&pageSize=10#packages";
    }
}
function search() {
    console.log("click")
    if (searchValue.value) {
        window.location.href = `https://auto-logistics-distribute.azurewebsites.net/Home/Search?column=productname&value=${searchValue.value}&isAscending=true&pageNumber=1&pageSize=10#packages`;
    }
}
videoBtn.forEach(btn =>{
 btn.addEventListener('click', ()=>{
  document.querySelector('.controls .active').classList.remove('active');
  btn.classList.add('active'); 
  let src = btn.getAttribute('data-src');
  document.querySelector('#video-slider').src= src;
 });
});

var swiper = new Swiper(".review-slider", {
 spaceBetween: 20,
 loop:true,
 autoplay: {
  delay: 2500,
  disableOnInteraction: false,
 },
 breakpoints: {
  640: {
   slidesPerView: 1,
  },
  768: {
   slidesPerView: 2,
  },
  1024: {
   slidesPerView: 3,
  },
 },
});



var swiper = new Swiper(".brand-slider", {
 spaceBetween: 20,
 loop:true,
 autoplay: {
  delay: 2500,
  disableOnInteraction: false,
 },
 breakpoints: {
  450: {
   slidesPerView: 2,
  },
  768: {
   slidesPerView: 3,
  },
  991: {
   slidesPerView: 4,
  },
  1200: {
   slidesPerView: 5,
  },
 },
});













