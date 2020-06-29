import React, { useContext } from "react";
import { Tab, Tabs, TabList, TabPanel } from "react-tabs";
import { CarContext } from "../car/CarProvider";
import Car from "../car/Car";
import "../car/Cars.css";
import { UserContext } from "../user/UserProvider";
import { LikedCarContext } from "../likedCar/LikedCarProvider";
import "./Profiles.css";
import { getUser } from "../../API/userManager";
import { EventContext } from "../event/EventProvider";
import Event from "../event/Event";
import { UserEventContext } from "../UserEvent/UserEventProvider";
import "react-tabs/style/react-tabs.css";

export default (props) => {
  const { cars } = useContext(CarContext);
  const { users } = useContext(UserContext);
  const { events } = useContext(EventContext);
  const { userEvents } = useContext(UserEventContext);
  const userId = JSON.parse(localStorage.getItem("user")).id;
  const { likedCars } = useContext(LikedCarContext);
  const currentUser = getUser();

  let editProfileMode = Boolean;

  if (userId !== props.match.params.userId) {
    editProfileMode = false;
  } else {
    editProfileMode = true;
  }

  const currentUserCars = cars.filter((car) => {
    return car.applicationUserId === props.match.params.userId;
  });

  const currentUsersLikedCars = [];

  {
    likedCars.forEach((rel) => {
      // Find the user and car matching like
      const foundLike = cars.find((car) => {
        return rel.userId === props.match.params.userId && rel.carId === car.id;
      });
      //if page is reloaded and no likes are found
      if (foundLike !== undefined) {
        currentUsersLikedCars.push(foundLike);
      }
    });
  }

  const currentUsersEvents = [];

  {
    userEvents.forEach((rel) => {
      // Find the user and car matching like
      const foundEvent = events.find((event) => {
        return (
          rel.userId === props.match.params.userId && rel.eventId === event.id
        );
      });
      //if page is reloaded and no likes are found
      if (foundEvent !== undefined) {
        currentUsersEvents.push(foundEvent);
      }
    });
  }

  let foundProfile = users.find(
    (user) => user.id === props.match.params.userId
  );
  let profileDescription = "";
  let profileHeader = "";
  let profileBackgroundPicturePath = "";
  let profilePicturePath = "";
  let firstName = "";
  let lastName = "";

  if (foundProfile !== undefined) {
    profileDescription = foundProfile.description;
    profileHeader = foundProfile.profileHeader;
    profileBackgroundPicturePath = foundProfile.profileBackgroundPicturePath;
    profilePicturePath = foundProfile.profilePicturePath;
    firstName = foundProfile.firstName;
    lastName = foundProfile.lastName;
  }

  return (
    <div className="profile top-space">
      <section className="userProfile">
        <div
          className="profileBackground"
          style={{
            //backgroundImage: "url(" + `${currentUser.name}` + ")",
            backgroundPosition: "center",
            // backgroundSize: 'cover',
            backgroundRepeat: "no-repeat",
            objectFit: "contain",
            maxwidth: "100%",
          }}
        >
          <span id="profileInfo">
            {
              <h1 className="currentProfileName">
                {firstName + " " + lastName}
              </h1>
            }

            {/* {
                            <button className="edit/follow_Button" onClick={evt => {

                                evt.preventDefault()
                                props.history.push(`edit/${currentUser.userName}`)

                            }}>{editProfileMode ? "Edit" : "Follow"}

                            </button>

                        } */}

            <div className="profile_description">{profileDescription}</div>

            <div className="profile_header">{profileHeader}</div>
          </span>
        </div>

        <div className="mainProfileSection">
          <Tabs>
            <TabList className="custom-tabs">
              <Tab>Cars</Tab>
              <Tab>Events</Tab>
              <Tab>Liked Cars</Tab>
            </TabList>

            <TabPanel className="tabPanel">
              <article className="profileCarList">
                <h3>Cars: {currentUserCars.length}</h3>

                {currentUserCars.map((car) => (
                  <Car key={car.id} car={car} {...props} />
                ))}
              </article>
            </TabPanel>
            <TabPanel className="tabPanel">
              <article className="events">
                <h3>Events {currentUsersEvents.length}</h3>

                {currentUsersEvents.map((event) => (
                  <Event key={event.id} event={event} {...props} />
                ))}
              </article>
            </TabPanel>
            <TabPanel className="tabPanel">
              <article id="likedCars" className="profileLikedCarList">
                <h3>Liked Cars {currentUsersLikedCars.length}</h3>

                {currentUsersLikedCars.map((car) => (
                  <Car key={car.id} car={car} {...props} />
                ))}
              </article>
            </TabPanel>
          </Tabs>
        </div>
      </section>
      <div class="divider div-transparent"></div>
    </div>
  );
};
