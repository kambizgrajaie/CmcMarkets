import { addTask, deleteTask, toggleTask, tasksSlice } from "./taskSlice";

describe("tasksSlice", () => {
  it("should handle addTask", () => {
    const initialState = [];
    const action = addTask({ task: "Test task" });
    const newState = tasksSlice.reducer(initialState, action);

    expect(newState).toHaveLength(1);
    expect(newState[0].name).toBe("Test task");
    expect(newState[0].completed).toBe(false);
  });

  it("should handle deleteTask", () => {
    const initialState = [
      { id: "1", name: "Task 1", completed: false },
      { id: "2", name: "Task 2", completed: true },
    ];
    const action = deleteTask({ id: "1" });
    const newState = tasksSlice.reducer(initialState, action);

    expect(newState).toHaveLength(1);
    expect(newState[0].id).toBe("2");
  });

  it("should handle toggleTask", () => {
    const initialState = [
      { id: "1", name: "Task 1", completed: false },
      { id: "2", name: "Task 2", completed: true },
    ];
    const action = toggleTask({ id: "1" });
    const newState = tasksSlice.reducer(initialState, action);

    expect(newState[0].completed).toBe(true);
  });
});
