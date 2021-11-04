import React, {Component} from 'react';
import { ListBox } from 'primereact/listbox';

class ListTest extends Component {

    constructor(props) {
        super(props);

        this.state = {
            selectedUser: null
        };

        this.gitUsers = [
            { login: 'New York', avatar: 'NY' },
            { login: 'Rome', avatar: 'RM' },
            { login: 'London', avatar: 'LDN' },
            { login: 'Istanbul', avatar: 'IST' },
            { login: 'Paris', avatar: 'PRS' }
        ];

        this.items = Array.from({ length: 100000 }).map((_, i) => ({ label: `Item #${i}`, value: i }));

        this.userTemplate = this.userTemplate.bind(this);
    }

    userTemplate(option) {
        return (
            <div className="user-item">
                <img alt="user image" src={option.avatar} onError={(e) => e.target.src = 'https://www.primefaces.org/wp-content/uploads/2020/05/placeholder.png'} className={`flag flag-${option.avatar.toLowerCase()}`} />
                <div>{option.login}</div>
            </div>
        );
    }

    render() {
        return (
            <div className="card">
                <ListBox value={this.state.selectedUser} options={this.props}  optionLabel="login" style={{ width: '15rem' }} />
            </div>
        );
    }
}
//onChange={(e) => this.setState({ selectedUser: e.value })}
 export default ListTest;