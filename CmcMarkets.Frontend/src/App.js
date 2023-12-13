import React from "react";
import AddTodo from "./components/AddTodo";
import TodoList from "./components/TodoList";
import styles from "./App.module.scss";
import ErrorBoundary from "./ErrorBoundary";

const App = () => {
  return (
    <ErrorBoundary>
      <div className={styles.app}>
        <h1>CMC Markets Todo App</h1>
        <AddTodo />
        <TodoList />
      </div>
    </ErrorBoundary>
  );
};

export default App;
