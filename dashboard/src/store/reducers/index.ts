import { combineReducers } from "redux";
import UserReducer from "./userReducers";
import CourseReducer from "./courseReducers";

export const rootReducer = combineReducers({
  UserReducer,
  CourseReducer,
});

export type RootState = ReturnType<typeof rootReducer>;
