import React, { Component } from "react";
import JobForm from "./components/Forms/NewJobForm";
import UserForm from "./components/Forms/UserForm";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <>
        <UserForm />
        {/* <JobForm /> */}
      </>
    );
  }
}
