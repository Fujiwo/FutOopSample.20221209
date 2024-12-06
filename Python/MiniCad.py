import tkinter as tk
from tkinter import Canvas

class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y

class Shape:
    def draw(self, canvas):
        pass

class Line(Shape):
    def __init__(self, start, end):
        self.start = start
        self.end = end

    def draw(self, canvas):
        canvas.create_line(self.start.x, self.start.y, self.end.x, self.end.y)

class Rectangle(Shape):
    def __init__(self, left_top, size):
        self.left_top = left_top
        self.size = size

    def draw(self, canvas):
        canvas.create_rectangle(self.left_top.x, self.left_top.y, self.left_top.x + self.size.width, self.left_top.y + self.size.height)

class Circle(Shape):
    def __init__(self, center, radius):
        self.center = center
        self.radius = radius

    def draw(self, canvas):
        canvas.create_oval(self.center.x - self.radius, self.center.y - self.radius, self.center.x + self.radius, self.center.y + self.radius)

class Polyline(Shape):
    def __init__(self, points):
        self.points = points

    def draw(self, canvas):
        for i in range(len(self.points) - 1):
            canvas.create_line(self.points[i].x, self.points[i].y, self.points[i + 1].x, self.points[i + 1].y)

class CadData:
    def __init__(self):
        self.figures = []

    def add_figure(self, figure):
        self.figures.append(figure)

    def remove_figure(self, figure):
        self.figures.remove(figure)

class Command:
    def execute(self):
        pass

    def undo(self):
        pass

class FigureCommand(Command):
    def __init__(self, figure):
        self.figure = figure

    def execute(self):
        pass

    def undo(self):
        pass

class CommandManager:
    def __init__(self):
        self.commands = []

    def execute_command(self, command):
        self.commands.append(command)
        command.execute()

    def undo(self):
        if self.commands:
            command = self.commands.pop()
            command.undo()

class Controller:
    def __init__(self, canvas, cad_data, command_manager):
        self.canvas = canvas
        self.cad_data = cad_data
        self.command_manager = command_manager
        self.current_figure = None

        self.canvas.bind("<Button-1>", self.on_mouse_down)
        self.canvas.bind("<B1-Motion>", self.on_mouse_move)
        self.canvas.bind("<ButtonRelease-1>", self.on_mouse_up)

    def on_mouse_down(self, event):
        self.start_point = Point(event.x, event.y)

    def on_mouse_move(self, event):
        if self.current_figure:
            self.canvas.delete(self.current_figure)
        self.end_point = Point(event.x, event.y)
        self.current_figure = self.canvas.create_line(self.start_point.x, self.start_point.y, self.end_point.x, self.end_point.y)

    def on_mouse_up(self, event):
        self.end_point = Point(event.x, event.y)
        line = Line(self.start_point, self.end_point)
        self.cad_data.add_figure(line)
        self.command_manager.execute_command(FigureCommand(line))
        self.current_figure = None

class CadView:
    def __init__(self, canvas):
        self.canvas = canvas

    def draw(self, cad_data):
        self.canvas.delete("all")
        for figure in cad_data.figures:
            figure.draw(self.canvas)

class MainMenu:
    def __init__(self, root, controller):
        self.controller = controller
        self.menu = tk.Menu(root)
        root.config(menu=self.menu)

        self.figure_menu = tk.Menu(self.menu, tearoff=0)
        self.menu.add_cascade(label="Figure", menu=self.figure_menu)
        self.figure_menu.add_command(label="Line", command=self.set_line_mode)

    def set_line_mode(self):
        self.controller.set_figure("line")

class Program:
    def __init__(self):
        self.root = tk.Tk()
        self.root.title("MiniCad")
        self.canvas = Canvas(self.root, width=800, height=600)
        self.canvas.pack()

        self.cad_data = CadData()
        self.command_manager = CommandManager()
        self.controller = Controller(self.canvas, self.cad_data, self.command_manager)
        self.cad_view = CadView(self.canvas)
        self.main_menu = MainMenu(self.root, self.controller)

    def main(self):
        self.root.mainloop()

if __name__ == "__main__":
    program = Program()
    program.main()
