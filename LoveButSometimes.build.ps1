task default

task TransformConfig_HappyPath {
    $transformer = ".\tools\WebConfigTransformRunner.1.0.0.1\WebConfigTransformRunner.exe"
    $config = ".\src\LoveButSometimes.config"
    $transformation = ".\src\LoveButSometimes.QA.config"
    $target = ".\deploy\LoveButSometimes.config"

    exec { &$transformer $config $transformation $target }
}

task TransformConfig_CloudsAndThunders {
    $transformer = ".\tools\WebConfigTransformRunner.1.0.0.1\WebConfigTransformRunner.exe"
    $config = ".\src\LoveButSometimes.config"
    $transformation = ".\src\LoveButSometimes.QAA.config"
    $target = ".\deploy\LoveButSometimes.config"

    exec { &$transformer $config $transformation $target }
}