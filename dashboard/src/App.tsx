import React from "react";
import { Routes, Route } from "react-router-dom";
import DashboardLayout from "./containers";
import DefaultPage from "./pages/defaultPage";
import Users from "./pages/users";

const App: React.FC = () => {
  return (
    <Routes>
      <Route path="/dashboard" element={<DashboardLayout />}>
        <Route index element={<DefaultPage />} />
        <Route path="users" element={<Users />} />
      </Route>
    </Routes>
  );
};

export default App;
