import React, { useContext, useState } from "react"
import { CarContext } from "../car/CarProvider"
import Car from "../car/Car"
import "../car/Cars.css"
import { UserContext } from "../user/UserProvider"
import { LikedCarContext } from "../likedCar/LikedCarProvider"
import LikedCar from "../likedCar/LikedCar"
import "./Profiles.css"
import { getUser } from "../../API/userManager"

export default (props) => {

    const { cars } = useContext(CarContext)
    const { users } = useContext(UserContext)
    const userName = JSON.parse(localStorage.getItem("user")).username
    const { likedCars } = useContext(LikedCarContext)
    const currentUser = getUser()
    const profilesArray = []

    let editProfileMode = Boolean

    if (userName !== JSON.parse(localStorage.getItem("user")).username) {
        let foundProfile = users.find(u => u.id === userName) || {}
        editProfileMode = false
        profilesArray.push(foundProfile)

    } else {
        let foundProfile = users.find(u => u.id === userName) || {}
        editProfileMode = true
        profilesArray.push(foundProfile)

    }

    const currentUserCars = cars.filter(car => {

        return car.applicationUserId === currentUser.id

    })

    const currentUsersLikedCars = [];

    {
        likedCars.forEach(rel => {

            // Find the user and car matching like
            const foundLike = cars.find(
                (car) => {
                    return rel.userId === currentUser.id && rel.carId === car.id
                }
            )
            //if page is reloaded and no likes are found
            if (foundLike !== undefined) {
                currentUsersLikedCars.push(foundLike)
            }
        })
    }

    let foundProfile = users.find(user => user.id == currentUser.id) //props match params - get user id from url for other users profile info

    let profileDescription = ""

    let profileHeader = ""

    let profileBackgroundPicturePath = ""

    let profilePicturePath = ""

    if (foundProfile !== undefined) {
        profileDescription = foundProfile.description
        profileHeader = foundProfile.profileHeader
        profileBackgroundPicturePath = foundProfile.profileBackgroundPicturePath
        profilePicturePath = foundProfile.profilePicturePath

    }

    return (

        <div className="profile">

            <section className="userProfile">

                <div className="profileBackground" style={{
                    backgroundImage: "url(" + `${currentUser.name}` + ")",
                    backgroundPosition: 'center',
                    // backgroundSize: 'cover',
                    backgroundRepeat: 'no-repeat',
                    objectFit: 'contain',
                    maxwidth: '100%'
                }}>

                    <span id="profileInfo">

                        {<h1 className="currentProfileName">{currentUser.username}</h1>}

                        {
                            <button className="followButton" onClick={evt => {

                                evt.preventDefault()
                                props.history.push(`edit/${currentUser.userName}`)

                            }}>{editProfileMode ? "Edit" : ""}

                            </button>}

                        <div className="profile_description">{profileDescription}</div>

                        <div className="profile_header">{profileHeader}</div>

                    </span>
                </div>

                <div className="mainProfileSection">
                    <article className="profileCarList">
                        <h3>Cars: {currentUserCars.length}</h3>

                        {currentUserCars.map(car => <Car key={car.id} car={car} {...props} />)}

                    </article>

                    <div className="profileSidebar">

                        <article id="likedCars" className="profileLikedCarList">

                            <h3>Liked Cars {currentUsersLikedCars.length}</h3>

                            {currentUsersLikedCars.map(car => <Car key={car.id} car={car} {...props} />)}

                        </article>
                    </div>

                </div>
            </section>
        </div>
    )
}