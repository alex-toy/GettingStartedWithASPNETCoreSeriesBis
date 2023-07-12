import React, { Component } from 'react';

export class Users extends Component {
  static displayName = Users.name;

  constructor(props) {
    super(props);
    this.state = { users: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(users) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Profession</th>
            <th>Age</th>
          </tr>
        </thead>
        <tbody>
          {users.map(user =>
                <tr key={user.Id}>
                <td>{user.Name}</td>
                <td>{user.Profession}</td>
                <td>{user.Age}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Users.renderForecastsTable(this.state.users);

    return (
      <div>
        <h1 id="tabelLabel" >Users</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
      const response = await fetch('User/users');
    const data = await response.json();
    this.setState({ users: data, loading: false });
  }
}
