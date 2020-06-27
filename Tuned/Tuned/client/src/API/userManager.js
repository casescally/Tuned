const baseUrl = "/api/v1";

export const createAuthHeaders = () => {
  const token = localStorage.getItem("token");
  return {
    Authorization: `bearer ${token}`,
    "Content-Type": "application/json",
  };
};

export const getUser = () => JSON.parse(localStorage.getItem("user"));

export const removeUser = () => localStorage.removeItem("user");

export const login = (user) => {
  return fetch(`${baseUrl}/auth/login`, {
    method: "POST",
    body: JSON.stringify(user),
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  })
    .then((response) => response.json())
    .then(handleAuthResponse);
};

export const register = (user) => {
  return fetch(`${baseUrl}/auth/register`, {
    method: "POST",
    body: JSON.stringify(user),
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  })
    .then((response) => response.json())
    .then(handleAuthResponse);
};

export const updateUser = (user) => {
  return fetch(`${baseUrl}/auth/register`, {
    method: "PUT",
    body: JSON.stringify(user),
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  })
    .then((response) => response.json())
    .then(handleAuthResponse);
};

export const saveImages = async (files) => {
  const authHeader = createAuthHeaders();
  const formData = new FormData();
  if (files) {
    Array.from(files).forEach(file => {
      formData.append(file.name, file);
    });
  }

  const response = await fetch('https://localhost:5001/api/UserImages', {

    // content-type header should not be specified!
    method: 'POST',
    headers: {
      authHeader,
    },
    body: formData,
    responseType: 'text'
  });
  return response.text();
}

const handleAuthResponse = (authResponse) => {
  if (!authResponse.success) {
    throw new AuthError(authResponse.errorMessages);
  }

  const { token, refreshTokenId } = authResponse;
  localStorage.setItem("token", token);
  localStorage.setItem("refresh", refreshTokenId);
  const { email, sub, id } = getTokenPayload(token);
  const user = {
    id: id,
    email: email,
    username: sub,
  };
  localStorage.setItem("user", JSON.stringify(user));
  return user;
};

const getTokenPayload = (token) => {
  const payload = token.split(".")[1];
  const base64 = payload.replace(/-/g, "+").replace(/_/g, "/");
  return JSON.parse(atob(base64));
};

function AuthError(messages) {
  this.messages = messages || [];
}
