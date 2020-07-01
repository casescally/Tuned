import React, { useState } from "react";
import { Link, withRouter } from "react-router-dom";
import { register } from "../API/userManager";

function Register({ history }) {
  const [username, setUsername] = useState();
  const [email, setEmail] = useState();
  const [firstName, setFirstName] = useState();
  const [lastName, setLastName] = useState();
  const [profilePicturePath, setProfilePicturePath] = useState();
  const [profileBackgroundPicturePath, setProfileBackgroundPicturePath] = useState();
  const [description, setDescription] = useState();
  const [profileHeader, setProfileHeader] = useState();
  const [streetAddress, setStreetAddress] = useState();
  const [password, setPassword] = useState();
  const [confirmPassword, setConfirmPassword] = useState();
  const [errors, setErrors] = useState([]);
  let activeUser = Boolean;
  activeUser = true;

  const submit = (event) => {
    event.preventDefault();
    setProfilePicturePath('none')
    setProfileBackgroundPicturePath('none')
    register({
      username,
      email,
      firstName,
      lastName,
      streetAddress,
      profilePicturePath,
      profileBackgroundPicturePath,
      description,
      profileHeader,
      password,
      confirmPassword,
      activeUser
    })
      .then((user) => history.push("/"))
      .catch((err) => {
        setErrors(err.messages || ["Whoops! Something unexpected happened..."]);
      });
  };

  return (
    <form onSubmit={submit}>
      <h1>Register</h1>
      <ul>
        {errors && errors.map((message, i) => <li key={i}>{message}</li>)}
      </ul>
      <div>
        <label htmlFor="username">Username</label>
        <input
          id="username"
          name="username"
          type="text"
          required
          onChange={(e) => setUsername(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="email">Email</label>
        <input
          id="email"
          name="email"
          type="email"
          required
          placeholder="example@email.com"
          onChange={(e) => setEmail(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="firstName">First Name</label>
        <input
          id="firstName"
          name="firstName"
          type="firstName"
          required
          placeholder="First Name"
          onChange={(e) => setFirstName(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="lastName">Last Name</label>
        <input
          id="lastName"
          name="lastName"
          type="lastName"
          required
          placeholder="Last Name"
          onChange={(e) => setLastName(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="streetAddress">Street Address</label>
        <input
          id="streetAddress"
          name="streetAddress"
          type="streetAddress"
          required
          placeholder="Street Address"
          onChange={(e) => setStreetAddress(e.target.value)}
        />
      </div>
      {/* <div>
        <label htmlFor="profilePicturePath">Profile Picture</label>
        <input
          id="profilePicturePath"
          name="profilePicturePath"
          type="profilePicturePath"
          required
          placeholder="Profile Picture"
          onChange={(e) => setProfilePicturePath(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="profileBackgroundPicturePath">Profile Backround Picture</label>
        <input
          id="profileBackgroundPicturePath"
          name="profileBackgroundPicturePath"
          type="profileBackgroundPicturePath"
          required
          placeholder="Profile Background Picture"
          onChange={(e) => setProfileBackgroundPicturePath(e.target.value)}
        />
      </div> */}
      <div>
        <label htmlFor="description">Profile Description</label>
        <input
          id="description"
          name="description"
          type="description"
          required
          placeholder="Profile Description"
          onChange={(e) => setDescription(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="profileHeader">Profile Header</label>
        <input
          id="profileHeader"
          name="profileHeader"
          type="profileHeader"
          required
          placeholder="Profile Header"
          onChange={(e) => setProfileHeader(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="password">Password</label>
        <input
          id="password"
          name="password"
          type="password"
          required
          onChange={(e) => setPassword(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="confirmPassword">Confirm Password</label>
        <input
          id="confirmPassword"
          name="confirmPassword"
          type="password"
          required
          onChange={(e) => setConfirmPassword(e.target.value)}
        />
      </div>
      <button type="submit">Register</button>
      <p>
        Already registered? <Link to="/login">Log in</Link>
      </p>
    </form>
  );
}

export default withRouter(Register);
