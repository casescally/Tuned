import React, { useState, useCallback, useContext, useEffect } from "react";
// import { createAuthHeaders } from '../API/userManager';
import { CarContext } from "./car/CarProvider";
import { LikedCarContext } from "./likedCar/LikedCarProvider";
import Car from "./car/Car";
import Carousel from "react-bootstrap/Carousel";
import { render } from "react-dom";
function Home() {
  const { cars } = useContext(CarContext);
  const [carImages, setCarImages] = useState([]);
  const { likedCars } = useContext(LikedCarContext);
  let top5LikedCars = likedCars.sort((a, b) => b - a).slice(0, 5);
  // let top5LikedCarsImages = cars.filter(
  //   (car) => car.id === top5LikedCars.carId
  // );
  console.log("carObjIMAG====>>", cars);
  const [index, setIndex] = useState(0);

  const handleSelect = (selectedIndex, e) => {
    setIndex(selectedIndex);
  };

  //const [values, setValues] = useState([]);

  // useEffect(() => {
  //   const authHeader = createAuthHeaders();
  //   fetch('/api/v1/values', {
  //     headers: authHeader
  //   })
  //     .then(response => response.json())
  //     .then(setValues);
  // }, []);
  function ControlledCarousel() {
    const [index, setIndex] = useState(0);

    const handleSelect = (selectedIndex, e) => {
      setIndex(selectedIndex);
    };
  }
  let imagesArray = [];

  cars.forEach((car) => imagesArray.push(car.imageFileNames));
  //console.log("IMGZ", imagesArray);

  //console.log(imagesArray.forEach(arr => arr.split(1,2(array.forEach(element => {element.split(','))

  let anotherArr = [];
  let finalArr = [];
  imagesArray.forEach((arr) => anotherArr.push(arr.split(",")));
  anotherArr.forEach((otherArr) => otherArr.shift().slice(2, 2));
  anotherArr.forEach((el) => el.pop().slice(0, -2));
  anotherArr.forEach((aoqs) =>
    aoqs.forEach((qs) => finalArr.push(qs.slice(1, -1)))
  );
  console.log("array of all img paths=>", finalArr);
  //console.log(imagesArray.forEach(arr => arr.split(1,2))
  return (
    <>
      <Carousel activeIndex={index} onSelect={handleSelect}>
        <Carousel.Item>
          <img
            className="d-block w-100"
            src="holder.js/800x400?text=First slide&bg=373940"
            alt="First slide"
          />
          <Carousel.Caption>
            <h3>First slide label</h3>
            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
          </Carousel.Caption>
        </Carousel.Item>
      </Carousel>
    </>
  );
}

export default Home;
