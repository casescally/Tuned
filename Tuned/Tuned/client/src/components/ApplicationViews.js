import React from "react";
import { Route } from "react-router-dom";
import Home from "./Home";
import { CarProvider } from "./car/CarProvider"
import { EventProvider } from "./event/EventProvider"
import { UserProvider } from "./user/UserProvider"
import Profile from "../components/profile/Profile"
import CarForm from "./car/CarForm"
import CarDetails from "./car/CarDetails"
import ProfileForm from "./profile/ProfileForm"
import { LikedCarProvider } from "./likedCar/LikedCarProvider"

export default function ApplicationViews() {
  return (
    <>
      <UserProvider>
        <CarProvider>
          <EventProvider>
            <LikedCarProvider>
              <Route exact path="/" render={() => <Home />} />

              <Route exact path="/users/:userId(\d+)" render={

                props => <Profile {...props} />

              } />

              <Route exact path="/cars/create" render={

                props => <CarForm {...props} />

              } />

              <Route path="/cars/:carId(\d+)" render={

                props => <CarDetails {...props} />

              } />

              <Route path="/cars/edit/:carId(\d+)" render={

                props => <CarForm {...props} />

              } />

              <Route exact path="/users/edit/:userId(\d+)" render={

                props => <ProfileForm {...props} />

              } />
            </LikedCarProvider>
          </EventProvider>
        </CarProvider>
      </UserProvider>
    </>
  );
}
