import React, { useContext, useState, useEffect } from "react"
import { UserContext } from "../user/UserProvider"
import { LikedCarContext } from "../likedCar/LikedCarProvider"
import { CarContext } from "./CarProvider"
import "./Cars.css"
import { getUser, createAuthHeaders } from "../../API/userManager"
import ThumbnailGallery from '../thumbnail-gallery/Thumbnail-Gallery'

export default (props) => {

    const { cars, deleteCar } = useContext(CarContext)
    const [carImages, setCarImages] = useState([])
    const { likedCars, addLikedCar, deleteLikedCar } = useContext(LikedCarContext)
    const { users } = useContext(UserContext)

    console.log('car images=s==>>', carImages)
    

    const chosenCarId = parseInt(props.match.params.carId, 10)
    
    const user = getUser()
    const car = cars.find(c => c.id === chosenCarId) || {};
    //const likedCar = likedCars.find(l => l.likedCarId === car.id) || {}
    const carUser = users.find(u => u.id === car.applicationUserId) || {}
    //const currentUsersCars = cars.filter(c => c.userId === user.id)
    let likedCarMode = Boolean

    const constructNewLikedCar = (currentCar) => {

        const alreadyLikedCarRel = likedCars.find(likedCar => likedCar.carId === currentCar.id && likedCar.user.id === user.id)

        //Don't allow duplicate liked cars

        if (alreadyLikedCarRel === undefined || null) {

            likedCarMode = false
            
            addLikedCar({

                carId: currentCar.id,

                userId: user.id

            })

        } else if (alreadyLikedCarRel !== undefined || null) {

            likedCarMode = true

            deleteLikedCar(alreadyLikedCarRel)

        }

    }

    useEffect(() => {
        const images = car.imageFileNames;
        if (images) setCarImages(JSON.parse(images))
    }, [car])


console.log(car)
    
    //let imagePathName = JSON.parse(car.carPageCoverUrl)[0].slice(2)
    
    // let imagePathName = JSON.parse(car.carPageCoverUrl)[0].slice(2)
    // const getCarImage = () => {
    //     const authHeader = createAuthHeaders();
    //     return fetch(`https://localhost:5001/api/CarImages/image/get?imageName=${imagePathName}`).then(setCarImage(), {

    //         headers: authHeader
    //     })

    //         .then(res => res.json())

    //         .then(setCarImage)

    // }

    // useEffect(() => {

    //     getCarImage()

    // }, [])

    // useEffect(() => {

    //     console.log("****  CAR APPLICATION STATE CHANGED  ****")
    //     console.log(carImage)

    // }, [carImage])

    return (
        <section className="car">
            {/*carImages.map((image, i) => <img key={i} src={`https://localhost:5001/api/CarImages/image/get?imageName=${image}`} alt="Image of car"/>)*/}
            {car.id && <div>
            <h3 className="car__name">{car.name}</h3>
            <div className="car__make">{car.make}</div>
            <div className="car__model">{car.model}</div>
            <div className="car__year">{car.year}</div>
            <div className="car__description">{car.carDescription}</div>
            <div><ThumbnailGallery images={carImages} /></div>

            <button className="likeButton" value="Like" onClick={evt => {

                evt.preventDefault()

                constructNewLikedCar(car)

            }

            }>{likedCarMode ? "Like" : "Unlike"}</button>

            <div className="car__user">User: {carUser.firstName + ' ' + carUser.lastName}</div>
            
            <button onClick={
                () => {

                    deleteCar(car)
                        .then(() => {
                            props.history.push("/cars")
                        })
                }
            }>
                Delete Car

            </button>

            <button onClick={() => {
                props.history.push(`/cars/edit/${car.id}`)
            }}>Edit
            
            </button>
            </div>}
        </section>
    )
}

