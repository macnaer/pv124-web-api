import axios from "axios";

const instance = axios.create({
  baseURL: "https://localhost:5000/api/User",
  headers: {
    "Content-Type": "application/json",
  },
});

const responseBody: any = (response: any) => response.data;

const request = {
  get: (url: string) => instance.get(url).then().then(responseBody),
  post: (url: string, body?: any) =>
    instance.post(url, body).then().then(responseBody),
};

const User = {
  Incert: (user: any) => request.post("/register", user),
};

export async function Incert(user: any) {
  const data = await User.Incert(user)
    .then((response) => {
      return { response };
    })
    .catch((error) => {
      return error.response;
    });
  console.log("In service ", data);
  return data;
}
