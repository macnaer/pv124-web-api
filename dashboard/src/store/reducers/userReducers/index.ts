import { UserState, UserActions, UserActionType } from "./types";

const initialState: UserState = {
  allUsers: [],
  loading: false,
  message: "",
  isAuth: false,
  user: {},
  selectedUser: null,
};
const UserReducer = (state = initialState, action: UserActions): UserState => {
  console.log("UserReducer", action);
  switch (action.type) {
    case UserActionType.START_REQUEST:
      return { ...state, loading: true };
    case UserActionType.ALL_USERS_LOADED:
      return { ...state, loading: false, allUsers: action.payload };
    case UserActionType.FINISH_REQUEST:
      return { ...state, loading: false, message: action.payload };
    case UserActionType.LOGIN_USER_SUCCESS:
      return {
        ...state,
        isAuth: true,
        loading: false,
        user: action.payload.decodedToken,
        message: action.payload.message,
      };
    default:
      return state;
  }
};

export default UserReducer;
