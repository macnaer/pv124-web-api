export interface UserState {
    allUsers: any,
    loading: boolean
}

export enum UserActionType{
    START_REQUEST = "START_REQUEST",
    ALL_USERS_LOADED = "ALL_USERS_LOADED"
}


interface StartRequestAction{
    type: UserActionType.START_REQUEST
}

interface AllUsersLoadedAction{
    type: UserActionType.ALL_USERS_LOADED,
    payload: any
}

export type UserActions = StartRequestAction | AllUsersLoadedAction;