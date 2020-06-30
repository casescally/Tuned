import React, { useState, useContext } from "react";
import { CarContext } from "./car/CarProvider";
import { LikedCarContext } from "./likedCar/LikedCarProvider";
import Carousel from 'react-bootstrap/Carousel'

function Home() {
  const [index, setIndex] = useState(0);

  const handleSelect = (selectedIndex, e) => {
    setIndex(selectedIndex);
  };
  const { cars } = useContext(CarContext);
  const { likedCars } = useContext(LikedCarContext);
  let top5LikedCars = likedCars.sort((a, b) => b - a).slice(0, 5);
  // let top5LikedCarsImages = cars.filter(
  //   (car) => car.id === top5LikedCars.carId
  // );
  let imagesArray = [];
  cars.forEach((car) => imagesArray.push(car.imageFileNames));
  let anotherArr = [];
  let finalArr = [];
  imagesArray.forEach((arr) => anotherArr.push(arr.split(",")));
  anotherArr.forEach((otherArr) => otherArr.shift().slice(2, 2));
  anotherArr.forEach((el) => el.pop().slice(0, -2));
  anotherArr.forEach((aoqs) =>
    aoqs.forEach((qs) => finalArr.push(qs.slice(1, -1)))
  );

//console.log("array of all img paths=>", finalArr);

  return (
    <>
       <Carousel alt="Most Liked Car Images" className="carousel" activeIndex={index} onSelect={handleSelect}>
         {finalArr.map((image, i) => (
          <Carousel.Item>
             <img
               key={i}
               className="d-block w-100"
               src={`https://localhost:5001/api/CarImages/image/get?imageName=${image}`}
               alt="First slide"
             />
           </Carousel.Item>
         ))}
       </Carousel>
       <h1 className="mainTitle">Hello and welcome to #TUNED! The social network for custom car enthusiasts to share pictures of your ride and see events in your area</h1>
    </>
  )
}

export default Home;