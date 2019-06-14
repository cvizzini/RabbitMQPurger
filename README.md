# RabbitMQPurger
Remove all messages in all [Rabbit MQ](https://www.rabbitmq.com/) Queues

----
## Usage

Set the connection settings in the appsettings.config

    <appSettings>
        <add key="rabbitUrl" value="http://localhost:15672/"/>
        <add key="Hostname" value="localhost"/>
        <add key="Username" value="guest"/>
        <add key="Password" value="guest"/>
        <add key="ApiAuthorizationValue" value="Basic Z3Vlc3Q6Z3Vlc3Q="/>
    </appSettings>

Build and Run

## Example Expected Output

    ****Rabbit Mq Queues Removal Tool****

    Aquiring the appSettings.config values...Done

    Starting the rabbit purgery on http://localhost:15672/

    Killing Queue Test-ActivityFeed...Done
    Killing Queue Test-Allocations...Done
    Killing Queue Test-Definitions...Done
    Killing Queue Test-Definitions_error...Done

    Completed the rabbit purgery
    Press enter to quit...


