# FutOopSample.20221209

## OOP.Samples.JavaScript


### BlockBreaker.OOP.1.html

#### Class Diagram

```mermaid
classDiagram
    class Canvas {
        -canvasElement: HTMLElement
        -context: CanvasRenderingContext2D
        +Canvas(canvasId: string)
        +width: number
        +height: number
        +offsetLeft: number
        +clear(): void
    }
```

### BlockBreaker.OOP.5.html

#### Class Diagram

```mermaid
classDiagram
    class Canvas {
        - canvasElement
        - context
        + get width()
        + get height()
        + get offsetLeft()
        + clear()
        + drawCircle(x, y, radius, fillStyle)
        + drawRectangle(x, y, width, height, fillStyle)
        + drawText(text, x, y, font, fillStyle)
    }

    class Ball {
        + static radius
        - x0
        - y0
        - dx0
        - dy0
        - x
        - y
        - dx
        - dy
        + constructor(x, y, dx, dy)
        + reset()
        + xTurn()
        + yTurn()
        + move()
        + moveTo(x, y)
        + draw(canvas)
    }

    class Paddle {
        + static height
        + static width
        - x0
        - x
        + constructor(maxWidth)
        + draw(canvas)
        + moveTo(x)
        + moveRight()
        + moveLeft()
        + reset()
    }

    class Brick {
        + static width
        + static height
        - x
        - y
        - status
        + constructor(x, y)
        + moveTo(x, y)
        + draw(canvas)
    }

    class Bricks {
        + static rowCount
        + static columnCount
        + static offsetTop
        + static offsetLeft
        + static padding
        - bricks
        + constructor()
        + draw(canvas)
        + collisionDetection(ball, score)
    }

    class BlockBreakerGame {
        - canvas
        - ball
        - paddle
        - bricks
        - score
        - lives
        - rightPressed
        - leftPressed
        + constructor()
        + drawScore(canvas, score)
        + drawLives(canvas, lives)
        + keyDownHandler(e)
        + keyUpHandler(e)
        + mouseMoveHandler(e)
        + draw(canvas)
        + moveBall()
        + movePaddle()
    }

    BlockBreakerGame --> Canvas
    BlockBreakerGame --> Ball
    BlockBreakerGame --> Paddle
    BlockBreakerGame --> Bricks
    Bricks --> Brick
```

### BlockBreaker.OOP.6.html

#### Class Diagram

```mermaid
classDiagram
    class Size {
        +width: number
        +height: number
        +Size(width: number, height: number)
        +clone(): Size
    }

    class Point {
        +x: number
        +y: number
        +Point(x: number, y: number)
        +clone(): Point
        +plusEqual(size: Size): void
    }

    class Rectangle {
        +leftTop: Point
        +size: Size
        +Rectangle(leftTop: Point, size: Size)
    }

    class Circle {
        +center: Point
        +radius: number
        +Circle(center: Point, radius: number)
    }

    class Canvas {
        -canvasElement: HTMLElement
        -context: CanvasRenderingContext2D
        +Canvas(canvasId: string)
        +size: Size
        +offsetLeft: number
        +clear(): void
        +drawCircle(circle: Circle, fillStyle: string): void
        +drawRectangle(rectangle: Rectangle, fillStyle: string): void
        +drawText(text: string, point: Point, font: string, fillStyle: string): void
    }

    class Ball {
        +position0: Point
        +velocity0: Size
        +position: Point
        +velocity: Size
        +Ball(position: Point, velocity: Size)
        +reset(): void
        +xTurn(): void
        +yTurn(): void
        +move(): void
        +moveTo(position: Point): void
        +draw(canvas: Canvas): void
    }

    class Paddle {
        +x0: number
        +x: number
        +Paddle(maxWidth: number)
        +draw(canvas: Canvas): void
        +moveTo(x: number): void
        +moveRight(): void
        +moveLeft(): void
        +reset(): void
    }

    class Brick {
        +position: Point
        +status: number
        +Brick(position: Point)
        +moveTo(position: Point): void
        +draw(canvas: Canvas): void
    }

    class Bricks {
        +bricks: Brick[][]
        +Bricks()
        +draw(canvas: Canvas): void
        +collisionDetection(ball: Ball, score: number): number
    }

    class BlockBreakerGame {
        +canvas: Canvas
        +ball: Ball
        +paddle: Paddle
        +bricks: Bricks
        +score: number
        +lives: number
        +rightPressed: boolean
        +leftPressed: boolean
        +BlockBreakerGame()
        +drawScore(canvas: Canvas, score: number): void
        +drawLives(canvas: Canvas, lives: number): void
        +keyDownHandler(e: KeyboardEvent): void
        +keyUpHandler(e: KeyboardEvent): void
        +mouseMoveHandler(e: MouseEvent): void
        +draw(canvas: Canvas): void
        +moveBall(): void
        +movePaddle(): void
    }

    Canvas --> Size
    Canvas --> Point
    Canvas --> Circle
    Canvas --> Rectangle
    Ball --> Point
    Ball --> Size
    Paddle --> Point
    Paddle --> Size
    Brick --> Point
    Brick --> Size
    Bricks --> Brick
    Bricks --> Point
    Bricks --> Size
    BlockBreakerGame --> Canvas
    BlockBreakerGame --> Ball
    BlockBreakerGame --> Paddle
    BlockBreakerGame --> Bricks
    BlockBreakerGame --> Point
    BlockBreakerGame --> Size
```

### MiniCad.html

#### Class Diagram

```mermaid
classDiagram
    class Canvas {
        -canvasElement: HTMLElement
        -context: CanvasRenderingContext2D
        +Canvas(canvasId: string)
        +clear(): void
        +drawFreeLine(points: Point[], strokeStyle: string): void
        +drawLine(start: Point, end: Point, strokeStyle: string): void
        +drawRectangle(rectangle: Rectangle, strokeStyle: string): void
        +drawCircle(circle: Circle, strokeStyle: string): void
    }

    class Point {
        +x: number
        +y: number
        +Point(x: number, y: number)
    }

    class Rectangle {
        +leftTop: Point
        +size: Size
        +Rectangle(leftTop: Point, size: Size)
    }

    class Circle {
        +center: Point
        +radius: number
        +Circle(center: Point, radius: number)
    }

    class Size {
        +width: number
        +height: number
        +Size(width: number, height: number)
    }

    class MiniCad {
        -canvas: Canvas
        -currentFigure: string
        -points: Point[]
        +MiniCad(canvasId: string)
        +setFigure(figure: string): void
        +addPoint(point: Point): void
        +draw(): void
    }

    Canvas --> Point
    Canvas --> Rectangle
    Canvas --> Circle
    MiniCad --> Canvas
    MiniCad --> Point
    Rectangle --> Point
    Rectangle --> Size
    Circle --> Point
    Circle --> Size
```
