import React, { useContext } from "react"
import { CarContext } from "../car/CarProvider"
import Car from "../car/Car"
import "../car/Cars.css"
import { UserContext } from "../user/UserProvider"
import { LikedCarContext } from "../likedCar/LikedCarProvider"
import LikedCar from "../likedCar/LikedCar"
import "./Profiles.css"

export default (props) => {

    const { cars } = useContext(CarContext)
    const { users } = useContext(UserContext)
    const chosenUserName = JSON.parse(localStorage.getItem("user")).username
    const { likes } = useContext(LikedCarContext)
    const profilesArray = []

    let editProfileMode = Boolean

    if (chosenUserName !== JSON.parse(localStorage.getItem("user")).username) {
        let foundProfile = users.find(u => u.id === chosenUserName) || {}
        editProfileMode = false
        profilesArray.push(foundProfile)

    } else {
        let foundProfile = users.find(u => u.id === chosenUserName) || {}
        editProfileMode = true
        profilesArray.push(foundProfile)

    }

    const currentProfile = profilesArray[0]

    console.log(editProfileMode)

    // //const likesRelationships = likes.filter(like => like.userId === currentProfile.id)
    // const currentUsersLikes = []

    // {
    //     likesRelationships.forEach(rel => {

    //         // Find this relationships's matching user object
    //         const foundLike = cars.filter(
    //             (singleCar) => {
    //                 return rel.carId === singleCar.id
    //             }
    //         )[0]

    //         //if page is reloaded and no likes are found
    //         if (foundLike !== undefined) {
    //             currentUsersLikes.push(foundLike)
    //         }
    //     })
    // }

    const currentUserCars = cars.filter(car => {
        return car.userId === currentProfile.id

    })

    return (

        <div className="profile">

            <section className="userProfile">

                <div className="profileBackground" style={{
                    backgroundImage: "url(" + `${currentProfile.name}` + ")",
                    backgroundPosition: 'center',
                    // backgroundSize: 'cover',
                    backgroundRepeat: 'no-repeat',
                    objectFit: 'contain',
                    maxwidth: '100%'
                }}>

                    <span id="profileInfo">

                        <img id="profilePicture" className="profilePicture" alt={`${currentProfile.firstname}'s profile picture`} src={currentProfile.name}></img>

                        {<h1 className="currentProfileName">{currentProfile.name}</h1>}


                        {

                            <button className="followButton" onClick={evt => {

                                evt.preventDefault()
                                props.history.push(`edit/${currentProfile.username}`)

                            }}>{editProfileMode ? "Edit" : ""}

                            </button>}
                    </span>
                </div>



                <div className="mainProfileSection">
                    <article className="profileCarList">
                        <h3>Cars: {currentUserCars.length}</h3>

                        {currentUserCars.map(car => <Car key={car.id} car={car} {...props} />)}

                    </article>

                    <div className="profileSidebar">

                        <article id="profileCarCollections">


                        </article>

                        <article id="likedCars" className="profileLikesList">

                            <h3>Liked Cars</h3>

                        </article>
                    </div>

                </div>
            </section>
        </div>
    )
}