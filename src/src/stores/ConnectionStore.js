import { useNetInfo } from "@react-native-community/netinfo";
import { extendObservable } from 'mobx'
import React from 'react';

//userStore

class ConnectionStore extends React.Component {
    constructor() {
        super()
        extendObservable(this, {
            netInfo: undefined,
            isUserSearchOffline: false,
            isActivitySearchOffline: false,
            isLoading: false
        })
    }

    setNetInfo = netInfo => {
        this.setState({ netInfo })
    }
    UserSearchOffline(val) {
        this.isUserSearchOffline = val
    }
    ActivitySearchOffline(val) {
        this.isActivitySearchOffline = val
    }
    SetIsLoading(val) {
        this.isLoading = val
    }

    reset() {
        this.isUserSearchOffline = false;
        this.isActivitySearchOffline = false;
        this.isLoading = false;
    }

}

export default new ConnectionStore();