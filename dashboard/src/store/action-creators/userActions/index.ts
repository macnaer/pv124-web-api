import { Dispatch } from "redux";
import { UserActionType, UserActions } from "../../reducers/userReducers/types";
import { Incert } from "../../../services/api-user-service";

export const IncertUser = (user: any) => {
  console.log("Input data: ", user);
  return async (dispatch: Dispatch<UserActions>) => {
    try {
      dispatch({ type: UserActionType.START_REQUEST });
      const data = await Incert(user);
      console.log("data ", data);
      const { response } = data;
      console.log("IncertUser ", response);
    } catch {}
  };
};
