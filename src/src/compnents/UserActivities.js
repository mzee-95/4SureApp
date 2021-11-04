import React from 'react';
import UserActivity from '../stores/UserActivity';

import { Dialog } from "primereact/dialog";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';

class UserActivities extends React.Component {

    render() {
        return (
            <DataTable value={UserActivity.activities}>
                <Column field="type" header="Type"></Column>
                <Column field="repo" header="Repo"></Column>
                <Column field="date" header="Date"></Column>
            </DataTable>
        )
    }
}

export default UserActivities;