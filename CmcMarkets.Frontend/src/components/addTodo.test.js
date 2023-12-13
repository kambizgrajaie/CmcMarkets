import React from "react";
import { render, screen, fireEvent } from "@testing-library/react";
import { Provider } from "react-redux";
import configureStore from "redux-mock-store";
import AddTodo from "./AddTodo";
import { addTask } from "../redux/taskSlice";

const mockStore = configureStore();

describe("AddTodo component", () => {
  it("renders AddTodo component correctly", () => {
    const store = mockStore({});

    render(
      <Provider store={store}>
        <AddTodo />
      </Provider>
    );

    expect(screen.getByPlaceholderText("Add task")).toBeInTheDocument();
    expect(screen.getByText("Save")).toBeInTheDocument();
  });

  it("dispatches addTask action on form submission", () => {
    const store = mockStore({});

    render(
      <Provider store={store}>
        <AddTodo />
      </Provider>
    );

    // Simulate user input
    fireEvent.change(screen.getByPlaceholderText("Add task"), {
      target: { value: "Test task" },
    });

    // Simulate form submission
    fireEvent.submit(screen.getByRole("form"));

    // Check if the addTask action was dispatched
    const actions = store.getActions();
    expect(actions).toHaveLength(1);
    expect(actions[0]).toEqual(addTask({ task: "Test task" }));

    expect(screen.getByPlaceholderText("Add task").value).toBe("");
  });
});
