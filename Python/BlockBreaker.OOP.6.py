import tkinter as tk
import random

class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y

class Size:
    def __init__(self, width, height):
        self.width = width
        self.height = height

class Circle:
    def __init__(self, center, radius):
        self.center = center
        self.radius = radius

class Rectangle:
    def __init__(self, left_top, size):
        self.left_top = left_top
        self.size = size

class Canvas:
    def __init__(self, canvas):
        self.canvas = canvas

    def clear(self):
        self.canvas.delete("all")

    def draw_circle(self, circle, fill_style):
        self.canvas.create_oval(circle.center.x - circle.radius, circle.center.y - circle.radius,
                                circle.center.x + circle.radius, circle.center.y + circle.radius,
                                fill=fill_style)

    def draw_rectangle(self, rectangle, fill_style):
        self.canvas.create_rectangle(rectangle.left_top.x, rectangle.left_top.y,
                                     rectangle.left_top.x + rectangle.size.width,
                                     rectangle.left_top.y + rectangle.size.height,
                                     fill=fill_style)

    def draw_text(self, text, point, font, fill_style):
        self.canvas.create_text(point.x, point.y, text=text, font=font, fill=fill_style)

class Ball:
    radius = 10

    def __init__(self, position, velocity):
        self.position0 = position
        self.velocity0 = velocity
        self.position = Point(position.x, position.y)
        self.velocity = Size(velocity.width, velocity.height)

    def reset(self):
        self.position = Point(self.position0.x, self.position0.y)
        self.velocity = Size(self.velocity0.width, self.velocity0.height)

    def x_turn(self):
        self.velocity.width = -self.velocity.width

    def y_turn(self):
        self.velocity.height = -self.velocity.height

    def move(self):
        self.position.x += self.velocity.width
        self.position.y += self.velocity.height

    def draw(self, canvas):
        canvas.draw_circle(Circle(self.position, Ball.radius), "#0095DD")

class Paddle:
    size = Size(75, 10)
    move_size = 7

    def __init__(self, max_width):
        self.max_width = max_width
        self.x0 = self.x = (max_width - Paddle.size.width) / 2

    def draw(self, canvas):
        canvas.draw_rectangle(Rectangle(Point(self.x, canvas.canvas.winfo_height() - Paddle.size.height), Paddle.size), "#0095DD")

    def move_to(self, x):
        self.x = x
        self.adjust()

    def move_right(self):
        self.x += Paddle.move_size
        self.adjust()

    def move_left(self):
        self.x -= Paddle.move_size
        self.adjust()

    def reset(self):
        self.x = self.x0

    def adjust(self):
        if self.x < 0:
            self.x = 0
        elif self.x + Paddle.size.width > self.max_width:
            self.x = self.max_width - Paddle.size.width

class Brick:
    size = Size(75, 20)

    def __init__(self, position):
        self.position = position
        self.status = 1

    def move_to(self, position):
        self.position = position

    def draw(self, canvas):
        if self.status == 1:
            canvas.draw_rectangle(Rectangle(self.position, Brick.size), "#0095DD")

class Bricks:
    row_count = 5
    column_count = 3
    offset = Size(30, 30)
    padding = 10

    def __init__(self):
        self.bricks = []
        for column in range(Bricks.column_count):
            column_bricks = []
            for row in range(Bricks.row_count):
                column_bricks.append(Brick(Point(0, 0)))
            self.bricks.append(column_bricks)

    def draw(self, canvas):
        for column in range(Bricks.column_count):
            for row in range(Bricks.row_count):
                brick = self.bricks[column][row]
                if brick.status == 1:
                    position = Point(
                        (row * (Brick.size.width + Bricks.padding)) + Bricks.offset.width,
                        (column * (Brick.size.height + Bricks.padding)) + Bricks.offset.height
                    )
                    brick.move_to(position)
                    brick.draw(canvas)

    def collision_detection(self, ball, score):
        for column in range(Bricks.column_count):
            for row in range(Bricks.row_count):
                brick = self.bricks[column][row]
                if brick.status == 1:
                    if (ball.position.x > brick.position.x and
                        ball.position.x < brick.position.x + Brick.size.width and
                        ball.position.y > brick.position.y and
                        ball.position.y < brick.position.y + Brick.size.height):
                        ball.y_turn()
                        brick.status = 0
                        score += 1
                        if score == Bricks.row_count * Bricks.column_count:
                            print("YOU WIN, CONGRATS!")
                            return score
        return score

class BlockBreakerGame:
    def __init__(self, root):
        self.root = root
        self.canvas_widget = tk.Canvas(root, width=480, height=320, bg="#eee")
        self.canvas_widget.pack()
        self.canvas = Canvas(self.canvas_widget)
        self.ball = Ball(Point(self.canvas_widget.winfo_width() / 2, self.canvas_widget.winfo_height() - 30), Size(2, -2))
        self.paddle = Paddle(self.canvas_widget.winfo_width())
        self.bricks = Bricks()
        self.score = 0
        self.lives = 3
        self.right_pressed = False
        self.left_pressed = False

        self.root.bind("<KeyPress-Right>", self.key_down_handler)
        self.root.bind("<KeyPress-Left>", self.key_down_handler)
        self.root.bind("<KeyRelease-Right>", self.key_up_handler)
        self.root.bind("<KeyRelease-Left>", self.key_up_handler)
        self.canvas_widget.bind("<Motion>", self.mouse_move_handler)

        self.update()

    def key_down_handler(self, event):
        if event.keysym == "Right":
            self.right_pressed = True
        elif event.keysym == "Left":
            self.left_pressed = True

    def key_up_handler(self, event):
        if event.keysym == "Right":
            self.right_pressed = False
        elif event.keysym == "Left":
            self.left_pressed = False

    def mouse_move_handler(self, event):
        relative_x = event.x
        if relative_x > 0 and relative_x < self.canvas_widget.winfo_width():
            self.paddle.move_to(relative_x - Paddle.size.width / 2)

    def draw_score(self):
        self.canvas.draw_text(f"Score: {self.score}", Point(8, 20), "16px Arial", "#0095DD")

    def draw_lives(self):
        self.canvas.draw_text(f"Lives: {self.lives}", Point(self.canvas_widget.winfo_width() - 65, 20), "16px Arial", "#0095DD")

    def move_ball(self):
        if (self.ball.position.x + self.ball.velocity.width > self.canvas_widget.winfo_width() - Ball.radius or
            self.ball.position.x + self.ball.velocity.width < Ball.radius):
            self.ball.x_turn()
        if self.ball.position.y + self.ball.velocity.height < Ball.radius:
            self.ball.y_turn()
        elif self.ball.position.y + self.ball.velocity.height > self.canvas_widget.winfo_height() - Ball.radius:
            if (self.ball.position.x > self.paddle.x and
                self.ball.position.x < self.paddle.x + Paddle.size.width):
                self.ball.y_turn()
            else:
                self.lives -= 1
                if self.lives == 0:
                    print("GAME OVER")
                    self.root.quit()
                else:
                    self.ball.reset()
                    self.paddle.reset()

    def move_paddle(self):
        if self.right_pressed:
            self.paddle.move_right()
        if self.left_pressed:
            self.paddle.move_left()

    def update(self):
        self.canvas.clear()
        self.bricks.draw(self.canvas)
        self.ball.draw(self.canvas)
        self.paddle.draw(self.canvas)
        self.draw_score()
        self.draw_lives()
        self.score = self.bricks.collision_detection(self.ball, self.score)
        self.move_ball()
        self.move_paddle()
        self.ball.move()
        self.root.after(10, self.update)

if __name__ == "__main__":
    root = tk.Tk()
    root.title("Block Breaker Game")
    game = BlockBreakerGame(root)
    root.mainloop()
