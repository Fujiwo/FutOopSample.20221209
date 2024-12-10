# FutOopSample.20221209

## OOP.Samples.JavaScript

### BallSample.html

```mermaid
classDiagram
    class Vector2 {
        +x: number
        +y: number
        +Vector2(x: number, y: number)
    }

    class Ball {
        +position: Vector2
        +velocity: Vector2
        +radius: number
        +color: string
        +Ball(position: Vector2, velocity: Vector2, radius: number, color: string)
        +draw(context: CanvasRenderingContext2D): void
        +move(size: Vector2): void
    }

    class BallSet {
        +balls: Ball[]
        +BallSet()
        +add(ball: Ball): void
        +draw(context: CanvasRenderingContext2D): void
        +move(size: Vector2): void
    }

    class Program {
        -canvas: HTMLCanvasElement
        -context: CanvasRenderingContext2D
        -ballSet: BallSet
        +Program()
        +draw(): void
        +onClickCanvas(position: Vector2): void
        +createBall(): Ball
        +static createBallWithPosition(position: Vector2): Ball
        +toRelativePosition(position: Vector2): Vector2
    }

    BallSet --> Ball
    Program --> BallSet
    Program --> Vector2
    Ball --> Vector2
```

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
    Bricks "1" --> "*" Brick
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
    Bricks "1" --> "*" Brick
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
    class Shape {
        <<abstract>>
        +draw(context: CanvasRenderingContext2D): void
    }

    class Canvas {
        -canvasElement: HTMLElement
        -context: CanvasRenderingContext2D
        +Canvas(canvasId: string)
        +clear(): void
        +drawShape(shape: Shape): void
    }

    class FigureSetting {
        +strokeStyle: string
        +lineWidth: number
        +clone: FigureSetting
    }

    class Figure {
        <<abstract>>
        +draw(canvas: Canvas): void
    }

    class MouseEventAdapter {
        +onMouseDown(event: MouseEvent): void
        +onMouseMove(event: MouseEvent): void
        +onMouseUp(event: MouseEvent): void
    }

    class CadData {
        +figures: Figure[]
        +CadData()
        +addFigure(figure: Figure): void
        +removeFigure(figure: Figure): void
    }

    class Command {
        <<abstract>>
        +execute(): void
        +undo(): void
    }

    class FigureCommand {
        <<abstract>>
        +figure: Figure
        +FigureCommand(figure: Figure)
        +execute(): void
        +undo(): void
    }

    class CommandManager {
        +commands: Command[]
        +CommandManager()
        +executeCommand(command: Command): void
        +undo(): void
    }

    class Controller {
        +canvas: Canvas
        +cadData: CadData
        +commandManager: CommandManager
        +Controller(canvas: Canvas, cadData: CadData, commandManager: CommandManager)
        +onMouseDown(event: MouseEvent): void
        +onMouseMove(event: MouseEvent): void
        +onMouseUp(event: MouseEvent): void
    }

    class CadView {
        +canvas: Canvas
        +CadView(canvas: Canvas)
        +draw(cadData: CadData): void
    }

    class MainMenu {
        +MainMenu()
        +initialize(): void
    }

    class Program {
        +main(): void
    }

    Canvas --> Shape
    FigureCommand <|-- Command
    CommandManager o--> Command
    Controller --> CadData
    Controller --> CommandManager
    CadView o--> Canvas
    CadView --> CadData
    CadData "1" o--> "*" Figure
    CadData o--> FigureSetting
    Figure --> Canvas
    Figure o--> Shape
    Figure o--> FigureSetting
    Program o--> MainMenu
    Program o--> Controller
    Program o--> CadView
    Program o--> CadData
    Program o--> CommandManager
```

```mermaid
classDiagram
    class Shape {
        <<abstract>>
        +draw(context: CanvasRenderingContext2D): void
    }

    class Line {
        +start: Point
        +end: Point
        +Line(start: Point, end: Point)
        +draw(context: CanvasRenderingContext2D): void
    }

    class Rectangle {
        +leftTop: Point
        +size: Size
        +Rectangle(leftTop: Point, size: Size)
        +draw(context: CanvasRenderingContext2D): void
    }

    class Circle {
        +center: Point
        +radius: number
        +Circle(center: Point, radius: number)
        +draw(context: CanvasRenderingContext2D): void
    }

    class Polyline {
        +points: Point[]
        +Polyline(points: Point[])
        +draw(context: CanvasRenderingContext2D): void
    }

    class Figure {
        <<abstract>>
        +draw(canvas: Canvas): void
    }

    class LineFigure {
        +line: Line
        +LineFigure(line: Line)
        +draw(canvas: Canvas): void
    }

    class RectangleFigure {
        +rectangle: Rectangle
        +RectangleFigure(rectangle: Rectangle)
        +draw(canvas: Canvas): void
    }

    class CircleFigure {
        +circle: Circle
        +CircleFigure(circle: Circle)
        +draw(canvas: Canvas): void
    }

    class PolylineFigure {
        +polyline: Polyline
        +PolylineFigure(polyline: Polyline)
        +draw(canvas: Canvas): void
    }

    class Command {
        <<abstract>>
        +execute(): void
        +undo(): void
    }

    class FigureCommand {
        <<abstract>>
        +figure: Figure
        +FigureCommand(figure: Figure)
        +execute(): void
        +undo(): void
    }

    class FreeLineCommand {
        +figure: PolylineFigure
        +FreeLineCommand(figure: PolylineFigure)
        +execute(): void
        +undo(): void
    }

    class LineCommand {
        +figure: LineFigure
        +LineCommand(figure: LineFigure)
        +execute(): void
        +undo(): void
    }

    class RectangleCommand {
        +figure: RectangleFigure
        +RectangleCommand(figure: RectangleFigure)
        +execute(): void
        +undo(): void
    }

    class CircleCommand {
        +figure: CircleFigure
        +CircleCommand(figure: CircleFigure)
        +execute(): void
        +undo(): void
    }

    Shape <|-- Line
    Shape <|-- Rectangle
    Shape <|-- Circle
    Shape <|-- Polyline
    Figure <|-- LineFigure
    Figure <|-- RectangleFigure
    Figure <|-- CircleFigure
    Figure <|-- PolylineFigure
    FigureCommand <|-- FreeLineCommand
    FigureCommand <|-- LineCommand
    FigureCommand <|-- RectangleCommand
    FigureCommand <|-- CircleCommand
    Command <|-- FigureCommand
    Figure o--> Shape
    FigureCommand --> Figure
```
