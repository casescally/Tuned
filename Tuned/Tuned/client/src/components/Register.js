import React, { useState, useEffect } from "react";
import { Link, withRouter } from "react-router-dom";
import { register, updateUser, saveImages } from "../API/userManager";
import Dropzone from 'react-dropzone'

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
  const [newUsersFiles, setNewUsersFiles] = useState([])
  const [userImages, setUserImages] = useState([]);
  const [user, setUser] = useState({})
  let activeUser = Boolean;
  activeUser = true;
  const editMode = false
  const handleAddImage = files => {
    const newProfilePicturePath = files.map(file => URL.createObjectURL(file));
    setProfilePicturePath(newProfilePicturePath);
    setNewUsersFiles(newProfilePicturePath)
  }



  const submit = (event) => {
    const newUser = Object.assign({}, user)
    newUser[event.target.name] = event.target.value
    setUser(newUser)
    let filePaths = [];
    if (editMode !== true) {
      let existingImgs = userImages.filter(user => !user.startsWith('blob'));
      event.preventDefault();
      if (newUsersFiles.length) {

        const filePaths = JSON.parse(saveImages(newUsersFiles));

        console.log(filePaths)
        existingImgs = existingImgs.concat(filePaths);
      }
      register({
        username,
        email,
        firstName,
        lastName,
        streetAddress,
        profilePicturePath: JSON.stringify(filePaths[0]),
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
    } else if (editMode) {
      event.preventDefault();
      updateUser({
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
    }
  };

  useEffect(() => {
    const images = user.profilePicturePath;
    if (images) setUserImages(JSON.parse(images))
  }, [user.profilePicturePath])

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
      <Dropzone onDrop={handleAddImage}>
        {({ getRootProps, getInputProps }) => (
          <section>
            <div {...getRootProps()}>
              <input {...getInputProps()} />
              <p>Drag 'n' drop some files here, or click to select files</p>
            </div>
          </section>
        )}
      </Dropzone>
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
      </div>
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
