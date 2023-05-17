import { Dispatch } from "redux";
import {
  CourseActionType,
  CourseActions,
} from "../../reducers/courseReducers/types";
import { toast } from "react-toastify";

import { GetAll } from "../../../services/api-course-service";

// export const IncertUser = (user: any) => {
//   return async (dispatch: Dispatch<UserActions>) => {
//     try {
//       dispatch({ type: UserActionType.START_REQUEST });
//       const data = await Incert(user);
//       const { response } = data;

//       if (response.success) {
//         toast.success(response.message);
//       } else {
//         toast.error(response.message);
//       }
//       dispatch({
//         type: UserActionType.FINISH_REQUEST,
//         payload: response.message,
//       });
//     } catch {}
//   };
// };

export const GetAllCourses = () => {
  return async (dispatch: Dispatch<CourseActions>) => {
    try {
      dispatch({ type: CourseActionType.START_REQUEST });
      const data = await GetAll();
      const { response } = data;
      console.log("GetAllCourses ", response);
      if (response.success) {
        dispatch({
          type: CourseActionType.ALL_COURSES_LOADED,
          payload: response.payload,
        });
      } else {
        toast.error(response.message);
      }
    } catch {}
  };
};
