#!/bin/bash

get_config () {
    jq -r --arg param "$1" '.[$param]' < /app/mqtt.json
}

MQTT_SERVER="$(get_config server)"
MQTT_PORT="$(get_config port)"
MQTT_TOPIC="$(get_config topic)"
MQTT_DEVICENAME="$(get_config devicename)"
MQTT_USERNAME="$(get_config username)"
MQTT_PASSWORD="$(get_config password)"

pushMQTTData () {
    local var="$1" value="$2"

    mosquitto_pub \
        -h "$MQTT_SERVER" \
        -p "$MQTT_PORT" \
        -u "$MQTT_USERNAME" \
        -P "$MQTT_PASSWORD" \
        -t "$MQTT_TOPIC/sensor/${MQTT_DEVICENAME}_$var" \
        -m "$value"
}

dict_filter_null_with () {
    local dict="$1"
    shift
    jq '
        $ARGS.positional |
        map(
            {"key": ., "value": $inputs[.]} |
            select (.value != null)
        ) | from_entries' -n \
        --argjson inputs "$dict" \
        --args "$@"
}

dict_to_associative_array () {
    echo "( $(jq -r '
        . |
        to_entries |
        map("[\(.key | @sh)]=\(.value | tostring | @sh)") |
        join(" ")
    ') )"
}

SENSORS=(
    WorkStateNo
    AcVoltageGrade
    RatedPower
    BatteryVoltage
    InverterVoltage
    GridVoltage
    BusVoltage
    ControlCurrent
    InverterCurrent
    GridCurrent
    LoadCurrent
    PInverter
    PGrid
    PLoad
    LoadPercent
    SInverter
    SGrid
    SLoad
    QInverter
    QGrid
    QLoad
    InverterFrequency
    GridFrequency
    InverterMaxNumber
    CombineType
    InverterNumber
    AcRadiatorTemp
    TransformerTemp
    DcRadiatorTemp
    InverterRelayStateNo
    GridRelayStateNo
    LoadRelayStateNo
    NLineRelayStateNo
    DcRelayStateNo
    EarthRelayStateNo
    Error1
    Error2
    Error3
    Warning1
    Warning2
    BattPower
    BattCurrent
    BattVoltageGrade
    RatedPowerW
    CommunicationProtocalEdition
    ArrowFlag
    ChrWorkstateNo
    MpptStateNo
    ChargingStateNo
    PvVoltage
    ChrBatteryVoltage
    ChargerCurrent
    ChargerPower
    RadiatorTemp
    ExternalTemp
    BatteryRelayNo
    PvRelayNo
    ChrError1
    ChrWarning1
    BattVolGrade
    RatedCurrent
    AccumulatedDay
    AccumulatedHour
    AccumulatedMinute
    # Composite
    BatteryPercent
    AccumulatedChargerPower
    AccumulatedDischargerPower
    AccumulatedBuyPower
    AccumulatedSellPower
    AccumulatedLoadPower
    AccumulatedSelfusePower
    AccumulatedPvsellPower
    AccumulatedGridChargerPower
    AccumulatedPvPower
)

INVERTER_DATA="$(timeout 10 dotnet inverter.dll poll -a=false)"
# shellcheck disable=2155
declare -A SENSORS_DATA="$(
    dict_filter_null_with "$INVERTER_DATA" "${SENSORS[@]}" | \
    dict_to_associative_array
)"

for sensor in "${!SENSORS_DATA[@]}"; do
    pushMQTTData "$sensor" "${SENSORS_DATA["$sensor"]}"
done