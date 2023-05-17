import * as UserActionCreators from "./userActions";
import * as CourseActionCreators from "./courseActions";

export default {
  ...UserActionCreators,
  ...CourseActionCreators,
};
