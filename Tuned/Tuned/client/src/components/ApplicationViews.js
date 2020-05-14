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
import { CarList } from "./car/CarList"

export default function ApplicationViews(props) {

  return (
    <>
      <UserProvider>
        <CarProvider>
          <EventProvider>
            <LikedCarProvider>

              <Route exact path="/" render={props => <Home {...props} />} />

              <Route exact path="/Cars" render={(props) => <CarList {...props} />} />

              <Route exact path="/cars/create" render={
                props => <CarForm {...props} />
              } />

              <Route path="/cars/:carId(\d+)" render={
                props => <CarDetails {...props} />
              } />

              <Route path="/profile/:userId" render={
                props => <Profile {...props} />
              } />

            </LikedCarProvider>
          </EventProvider>
        </CarProvider>
      </UserProvider>
    </>
  );
}
