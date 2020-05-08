import React from "react";
import { Route } from "react-router-dom";
import Home from "./Home";
import CarProvider from "./components/car/CarProvider"
import EventProvider from "./components/event/EventProvider"
import UserProvider from "./components/event/EventProvider"
import Profile from "./profile/Profile"
import CarForm from "./car/CarForm"
import CarDetails from "./car/CarDetails"
import ProfileForm from "./profile/ProfileForm"

export default function ApplicationViews() {
  return (
    <>
      <UserProvider>
        <CarProvider>
          <EventProvider>
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
          </EventProvider>
        </CarProvider>
      </UserProvider>
    </>
  );
}
