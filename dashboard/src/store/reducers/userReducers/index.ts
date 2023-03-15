import { UserState, UserActions, UserActionType } from "./types";

const initialState: UserState = {
  allUsers: [
    {
      id: 1,
      name: "Bill",
      surname: "Smith",
    },

    {
      id: 2,
      name: "Eva",
      surname: "Andesen",
    },
    {
      id: 3,
      name: "Stiven",
      surname: "Sigal",
    },
    {
      id: 4,
      name: "Rebert",
      surname: "Signal",
    },
    {
      id: 5,
      name: "Camilla",
      surname: "Tomson",
    },
    {
      id: 6,
      name: "Evan",
      surname: "Roberts",
    },
  ],
  loading: false,
};
const UserReducer = (state = initialState, action: UserActions): UserState => {
  switch (action.type) {
    case UserActionType.START_REQUEST:
      return { ...state, loading: true };
    case UserActionType.ALL_USERS_LOADED:
      return { ...state, loading: false, allUsers: action.payload };
    default:
      return state;
  }
};

export default UserReducer;
