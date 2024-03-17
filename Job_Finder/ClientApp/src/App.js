import React, { Component, useState } from "react";
import JobForm from "./components/Forms/NewJobForm";
import UserForm from "./components/Forms/UserForm";
import Header from "./components/Layout/Header";

export default function App() {
  const [userID, setUserID] = useState("");

  return (
    <main>
      <Header />
      {userID === "" ? <UserForm /> : <JobForm />}
    </main>
  );
}
