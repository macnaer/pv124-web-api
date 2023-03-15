import { UserState, UserActions, UserActionType } from "./types";

const initialState: UserState = {
    allUsers:[{
        id: 1,
        name: "Bill",
        surname: "Smith"
    }],
    loading: false
}
const UserReducer = (state = initialState, action: UserActions): UserState => {
    switch(action.type){
        case UserActionType.START_REQUEST:
            return { ...state, loading: true }
        case UserActionType.ALL_USERS_LOADED:
            return { ...state, loading: false, allUsers: action.payload }    
        default: 
        return state
    }
}

export default UserReducer;